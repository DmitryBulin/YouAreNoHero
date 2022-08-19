using System.Collections;
using UnityEngine;

/// <summary>
/// This class manages attack instructions for player
/// </summary>

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon = default;
    [SerializeField] private FloatVariable _attackCooldown = default;

    public bool CanAttack;

    private Vector3 _attackDirection;
    private bool _onCooldown;

    private void Awake()
    {
        CanAttack = true;
        _onCooldown = false;
        _attackDirection = new Vector2(0, 1);
    }

    public void ChangeDirection(Vector2 newDirection)
    {
        if (newDirection.Equals(Vector2.zero)) { return; }
        _attackDirection = newDirection;
    }

    public void Attack()
    {
        if (!CanAttack || _onCooldown) { return; }

        _currentWeapon.CreateAttack(transform.position, _attackDirection);

        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        float time = 0f;

        _attackCooldown.SetMaximum();
        while (time < _attackCooldown.MaximumValue)
        {
            time += Time.deltaTime;
            _attackCooldown.ChangeValue(-Time.deltaTime);
            yield return null;

        }

        _onCooldown = false;
    }
        

}
