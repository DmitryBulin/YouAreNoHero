using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    // This curve represents percentage of movement speed during dodge (1 - equal to movement speed, 2 - two times the movement speed)
    [SerializeField] private AnimationCurve _dodgeVelocityCurve;
    [SerializeField] private FloatVariable _dodgeCooldown;
    [SerializeField] private FloatVariable _dodgeTime;
    [SerializeField] private FloatVariable _movementSpeed;

    private Rigidbody2D _rigidbody;
    private bool _isDodging;
    private bool _canDodge;
    private Vector2 _movementVector;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _isDodging = false;
        _canDodge = true;
    }

    public void Dodge()
    {
        if (_isDodging || !_canDodge) { return; }
        _isDodging = true;
        _canDodge = false;
        _dodgeCooldown.SetMaximum();
        StartCoroutine(DodgeVelocityChange());
    }

    IEnumerator DodgeVelocityChange()
    {
        float time = 0f;
        Vector2 dodgeDirection = _movementVector;

        while (time < _dodgeVelocityCurve[_dodgeVelocityCurve.length - 1].time)
        {
            _rigidbody.velocity = dodgeDirection * _movementSpeed.Value * _dodgeVelocityCurve.Evaluate(time);
            yield return null;
            time += Time.deltaTime;
        }

        FinishedDodging();
    }

    public void FinishedDodging()
    {
        _isDodging = false;
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
        if (!_canDodge)
        {
            _dodgeCooldown.ChangeValue(-Time.deltaTime);
        }

        if (!_isDodging)
        {
            _rigidbody.velocity = _movementVector * _movementSpeed.Value;
        }

    }

}
