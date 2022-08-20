using UnityEngine;

/// <summary>
/// Data container for boss states
/// Can be used on different stages and is flexible to change
/// </summary>

[CreateAssetMenu(menuName = "Game / Boss State")]
public class BossState : ScriptableObject
{
    [Tooltip("Minimum and maximum values of a variable would be interpretated as the range of attacking with this weapon")]
    public FloatVariable AttackDistance;
    [Tooltip("This value would be taken for random-weighted calculation of next boss state")]
    public int StateWeight;
    [Tooltip("Indicates if this state can be chosen twice or more in a row")]
    public bool CanChain;
    [Tooltip("Maximum from this value would be taken for attack cooldown")]
    public FloatVariable AttackCooldown;
    [Tooltip("This weapon will be used if current state would be proceed")]
    public Weapon StateWeapon;
}
