using System.Collections;
using UnityEngine;

/// <summary>
/// This class handles entity's health and invincibility
/// </summary>

[RequireComponent(typeof(Collider2D))]
public class EntityHealth : MonoBehaviour, IPausable
{
    [SerializeField] private FloatVariable _health;

    [Tooltip("Time of invincibility after getting hit")]
    [SerializeField] private FloatVariable _invincibilityTime;

    [HideInInspector] public bool IsInvincible { get; set; }

    private bool _isAlive;
    private bool _canRecieveDamage;
    private bool _isPaused;

    private void Awake()
    {
        _isAlive = true;
        _canRecieveDamage = true;
        _isPaused = false;
        IsInvincible = false;
    }

    public void Pause()
    {
        _isPaused = true;
    }

    public void Unpause()
    {
        _isPaused = false;
    }

    public void Died()
    {
        _isAlive = false;
        GetComponent<Collider2D>().enabled = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AttackProjectile>() == null)
        {
            Debug.LogWarning("Health trigger collided with something that dont deal damage");
            return;
        }

        if (!_canRecieveDamage || !_isAlive || IsInvincible || _isPaused) { return; }


        float damage = collision.GetComponent<AttackProjectile>().DealDamage();
        _health.ChangeValue(-damage);
        StartCoroutine(Invincibility());
    }

    private IEnumerator Invincibility()
    {
        float time = 0f;

        _canRecieveDamage = false;
        _invincibilityTime.SetMaximum();

        while (time < _invincibilityTime.MaximumValue)
        {
            if (!_isPaused)
            {
                _invincibilityTime.ChangeValue(-Time.deltaTime);
                time += Time.deltaTime;
            }
            yield return null;
        }

        _canRecieveDamage = true;
    }

}
