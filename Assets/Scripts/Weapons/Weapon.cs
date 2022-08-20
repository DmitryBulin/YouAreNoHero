using UnityEngine;

/// <summary>
/// Data container for weapons
/// </summary>

[CreateAssetMenu(menuName = "Game / Weapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] AttackProjectile[] _attackPrefabs;


    // TODO: Not instantiating, but rather taking from pool
    public void CreateAttack(Vector3 position, Vector3 direction)
    {
        int projectileIndex = Random.Range(0, _attackPrefabs.Length);
        AttackProjectile newProjectile = Instantiate(_attackPrefabs[projectileIndex], position, Quaternion.identity);
        newProjectile.transform.up = direction;
    }

}
