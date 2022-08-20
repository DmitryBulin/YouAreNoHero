using UnityEngine;

/// <summary>
/// This class is for moving projectiles, for them to move towards their transform.up vector
/// </summary>

[RequireComponent(typeof(Rigidbody2D))]
public class PassiveMoving : MonoBehaviour
{
    [SerializeField] private FloatVariable _movementSpeed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = transform.up * _movementSpeed.Value;
    }

}
