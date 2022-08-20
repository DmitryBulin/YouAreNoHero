using System.Collections;
using UnityEngine;

/// <summary>
/// This class manages attack instructions for player
/// </summary>

public class PlayerAttack : MonoBehaviour, IPausable
{
    [SerializeField] private Weapon _currentWeapon = default;
    [SerializeField] private FloatVariable _attackCooldown = default;

    [HideInInspector] public bool CanAttack { get; set; }

    private Vector3 _attackDirection;
    private bool _onCooldown;
    private bool _isPaused;

    private void Awake()
    {
        CanAttack = true;
        _onCooldown = false;
        _isPaused = false;
        _attackDirection = new Vector2(0, 1);
    }

    public void Pause()
    {
        _isPaused = true;
    }

    public void Unpause()
    {
        _isPaused = false;
    }

    public void ChangeDirection(Vector2 newDirection)
    {
        if (newDirection.Equals(Vector2.zero)) { return; }
        _attackDirection = newDirection;
    }

    public void Attack()
    {
        if (!CanAttack || _onCooldown || _isPaused) { return; }

        _currentWeapon.CreateAttack(transform.position, _attackDirection);

        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        float time = 0f;

        _onCooldown = true;

        while (time < _attackCooldown.MaximumValue)
        {
            if (!_isPaused)
            {
                time += Time.deltaTime;
            }
            yield return null;

        }

        _onCooldown = false;
    }
        

}
