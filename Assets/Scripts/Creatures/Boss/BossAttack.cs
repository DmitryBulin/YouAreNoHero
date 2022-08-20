using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [Tooltip("Stages have to be sorted by health")]
    [SerializeField] private BossStage[] _stages;
    [SerializeField] private FloatVariable _bossHealth;
    [SerializeField] private VoidEventChannelSO _newStageChannel;
    [SerializeField] private FloatVariable _initialCooldown;
    [SerializeField] private Vector2EventChannelSO _bossAttackChannel;

    [HideInInspector] public bool CanAttack { get; set; }

    private Vector2 _attackDirection;
    private Vector3 _targetPosition;
    private bool _onCooldown;
    private BossStage _currentStage;
    private FloatVariable _attackCooldown;

    private void Awake()
    {
        CanAttack = true;
        _currentStage = default;

        UpdateHealth();
        StartCoroutine(Cooldown(_initialCooldown));
    }

    private void Update()
    {
        if (_onCooldown) { return; }
        Attack(); 
    }

    public void UpdateTargetDirection(Vector2 newPosition)
    {
        _targetPosition = newPosition;
        _attackDirection = (_targetPosition - transform.position).normalized;
        _bossAttackChannel.Invoke(_attackDirection);
    }

    public void UpdateHealth()
    {
        BossStage newStage = GetCurrentStage();
        if (!newStage.Equals(newStage))
        {
            _newStageChannel.Invoke();
        }
    }

    private void Attack()
    {
        if (!CanAttack) { return; }

        BossStage stage = GetCurrentStage();

        float targetDistance = (_targetPosition - transform.position).magnitude;
        BossState currentState = stage.GetState(targetDistance);
        currentState.StateWeapon.CreateAttack(transform.position, _attackDirection);

        StartCoroutine(Cooldown(currentState.AttackCooldown));
    }

    private BossStage GetCurrentStage()
    {
        float percentageHealth = _bossHealth.Value / _bossHealth.MaximumValue;
        for (int i = 0; i < _stages.Length; ++i)
        {
            if (_stages[i].HealthBoundaries.MaximumValue < percentageHealth)
            {
                return _stages[i];
            }
        }

        Debug.LogError("Something went wrong while choosing the boss stage. Check if health boundaries cover all hp cases (0..1)");
        return _stages[0];
    }

    private IEnumerator Cooldown(FloatVariable cooldownTime)
    {
        float time = 0f;

        _onCooldown = true;
        while (time < cooldownTime.MaximumValue)
        {
            time += Time.deltaTime;
            yield return null;
        }

        _onCooldown = false;
    }

}
