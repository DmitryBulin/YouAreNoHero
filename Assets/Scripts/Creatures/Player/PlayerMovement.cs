using System.Collections;
using UnityEngine;

/// <summary>
/// This class recieves movement and dodge instructions and proccess them 
/// </summary>

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, IPausable
{
    // This curve represents percentage of movement speed during dodge (1 - equal to movement speed, 2 - two times the movement speed)
    [SerializeField] private AnimationCurve _dodgeVelocityCurve;
    [SerializeField] private FloatVariable _dodgeCooldown;
    [SerializeField] private FloatVariable _movementSpeed;
    [SerializeField] private BoolEventChannelSO _dodgeChannel;
    
    [HideInInspector] public bool CanMove { get; set; }
    private Rigidbody2D _rigidbody;
    private bool _isDodging;
    private bool _canDodge;
    private bool _isPaused;
    private Vector2 _movementVector;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isDodging = false;
        _canDodge = true;
        _isPaused = false;
        _movementVector = Vector2.zero;
        CanMove = true;
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

    public void Dodge()
    {
        if (_isDodging || !_canDodge || _isPaused || _movementVector.Equals(Vector2.zero)) { return; }

        _isDodging = true;
        _canDodge = false;
        _dodgeCooldown.ChangeValue(-1f);

        StartCoroutine(DodgeVelocityChange());
    }

    IEnumerator DodgeVelocityChange()
    {
        float time = 0f;
        Vector2 dodgeDirection = _movementVector;

        _dodgeChannel.Invoke(true);
        while (time < _dodgeVelocityCurve[_dodgeVelocityCurve.length - 1].time)
        {
            if (!_isPaused)
            {
                _rigidbody.velocity = dodgeDirection * _movementSpeed.Value * _dodgeVelocityCurve.Evaluate(time);
                time += Time.deltaTime;
            }
            yield return null;
        }

        FinishedDodging();
    }

    public void FinishedDodging()
    {
        _isDodging = false;
        _dodgeChannel.Invoke(false);
    }

    public void DodgeCooldownZero()
    {
        _canDodge = true;
    }

    public void ChangeMovement(Vector2 newMovementVector)
    {
        _movementVector = newMovementVector;
    }

    private void Update()
    {
        if (!CanMove || _isPaused) { return; }

        if (!_canDodge)
        {
            _dodgeCooldown.ChangeValue(Time.deltaTime);
        }

        if (!_isDodging)
        {
            _rigidbody.velocity = _movementVector * _movementSpeed.Value;
        }

    }

}
