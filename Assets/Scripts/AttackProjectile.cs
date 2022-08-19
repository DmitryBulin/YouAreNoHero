using UnityEngine;

/// <summary>
/// This class is being put on projectile with according damage
/// After dealing damage once, it turns off the collider
/// </summary>

[RequireComponent(typeof(Collider2D))]
public class AttackProjectile : MonoBehaviour
{
    [SerializeField] private FloatVariable _damageOfAttack;
    
    public float DealDamage()
    {
        GetComponent<Collider2D>().enabled = false;
        return _damageOfAttack.Value;
    }

}
