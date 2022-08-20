using UnityEngine;

/// <summary>
/// This class is for moving projectiles, for them to move towards their transform.up vector
/// </summary>

[RequireComponent(typeof(Rigidbody2D))]
public class PassiveMoving : MonoBehaviour, IPausable
{
    [SerializeField] private FloatVariable _movementSpeed;

    private Rigidbody2D _rigidbody;
    private bool _isPaused;
    private Vector2 _velocityVect;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isPaused = false;
    }

    public void Pause()
    {
        _isPaused = true;
        _rigidbody.velocity = Vector2.zero;
    }

    public void Unpause()
    {
        _isPaused = false;
    }

    private void FixedUpdate()
    {
        if (_isPaused) { return; }
        _rigidbody.velocity = transform.up * _movementSpeed.Value;
    }

}
