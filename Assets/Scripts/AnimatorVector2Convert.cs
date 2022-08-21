using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorVector2Convert : MonoBehaviour
{
    [SerializeField] private string _animatorXPositiveAxis;
    [SerializeField] private string _animatorXNegativeAxis;
    [SerializeField] private string _animatorXAxisMoving;
    [SerializeField] private string _animatorYPositiveAxis;
    [SerializeField] private string _animatorYNegativeAxis;
    [SerializeField] private string _animatorYAxisMoving;

    private Animator _animator;
    private Vector2 _previousVect;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _previousVect = Vector2.zero;
    }

    public void SetAxises(Vector2 inputVect)
    {
        if (_previousVect.Equals(inputVect)) { return; }

        if (inputVect.x == 0)
        {
            _animator.SetBool(_animatorXAxisMoving, false);
        }
        else
        {
            _animator.SetBool(_animatorXAxisMoving, true);
            if (inputVect.x > 0)
            {
                _animator.SetTrigger(_animatorXPositiveAxis);
            }
            else if (inputVect.x < 0)
            {
                _animator.SetTrigger(_animatorXNegativeAxis);
            }
        }

        if (inputVect.y == 0)
        {
            _animator.SetBool(_animatorYAxisMoving, false);
        }
        else
        {
            _animator.SetBool(_animatorYAxisMoving, true);
            if (inputVect.y > 0)
            {
                _animator.SetTrigger(_animatorYPositiveAxis);
            }
            else if (inputVect.y < 0)
            {
                _animator.SetTrigger(_animatorYNegativeAxis);
            }
        }

        _previousVect = inputVect;
    }

}
