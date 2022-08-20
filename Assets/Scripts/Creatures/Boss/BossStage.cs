using UnityEngine;

/// <summary>
/// This class implements data container for boss stage
/// </summary>

[CreateAssetMenu(menuName = "Game / Boss Stage")]
public class BossStage : ScriptableObject
{
    [SerializeField] private BossState[] _bossStates;
    [Tooltip("Maximum value would be taken as a minimum hp in percentage for the boss to be in this stage")]
    public FloatVariable HealthBoundaries;

    private int _previousIndex;

    private void OnEnable()
    {
        _previousIndex = -1;
    }

    public BossState GetState(float distance)
    {
        int totalWeight = 0;
        for (int i = 0; i < _bossStates.Length; ++i)
        {
            if (i == _previousIndex && !_bossStates[_previousIndex].CanChain
                || distance < _bossStates[i].AttackDistance.MinimumValue
                || distance > _bossStates[i].AttackDistance.MaximumValue) { continue; }
            totalWeight += _bossStates[i].StateWeight;
        }
        
        int targetWeight = Random.Range(0, totalWeight);
        
        for (int i = 0; i < _bossStates.Length; ++i)
        {
            if (i == _previousIndex && !_bossStates[_previousIndex].CanChain
                || distance < _bossStates[i].AttackDistance.MinimumValue
                || distance > _bossStates[i].AttackDistance.MaximumValue) { continue; }

            targetWeight -= _bossStates[i].StateWeight;

            if (targetWeight <= 0)
            {
                _previousIndex = i;
                return _bossStates[i];
            }
        }

        Debug.LogError("Something went wrong with the weighted random..");
        return _bossStates[0];
    }

}
