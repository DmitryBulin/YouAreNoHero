using System.Collections;
using UnityEngine;

/// <summary>
/// This class handles entity's health and invincibility
/// </summary>

[RequireComponent(typeof(Collider2D))]
public class EntityHealth : MonoBehaviour
{
    [SerializeField] private FloatVariable _health;
    [SerializeField] private FloatVariable _invincibilityTime;

    private bool _isAlive;
    private bool _canRecieveDamage;

    private void Awake()
    {
        _isAlive = true;
        _canRecieveDamage = true;
    }

    public void Died()
    {
        _isAlive = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AttackProjectile>() == null)
        {
            Debug.LogWarning("Health trigger collided with something that dont deal damage");
            return;
        }

        if (!_canRecieveDamage || !_isAlive) { return; }

        float damage = collision.GetComponent<AttackProjectile>().DealDamage();
        _health.ChangeValue(-damage);
        StartCoroutine(Invincibility());
    }

    private IEnumerator Invincibility()
    {
        float time = 0f;

        _invincibilityTime.SetMaximum();
        while (time < _invincibilityTime.MaximumValue)
        {
            _invincibilityTime.ChangeValue(-Time.deltaTime);
            time += Time.deltaTime;
            yield return null;
        }

        _canRecieveDamage = true;
    }

}