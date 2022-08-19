using UnityEngine;

[CreateAssetMenu(menuName = "Data / Float")]
public class FloatVariable : ScriptableObject
{
    [SerializeField] private float _initialValue;
    [SerializeField] private float _minValue;
    [SerializeField] private float _maxValue;
    [SerializeField] private FloatEventChannelSO _onValueChanged;
    [SerializeField] private VoidEventChannelSO _onMinValueReached;
    [SerializeField] private VoidEventChannelSO _onMaxValueReached;
    
    public float Value { get; private set; }

    private void Awake()
    {
        Value = _initialValue;
    }

    public void ChangeValue(float changeAmount)
    {
        if (changeAmount == 0f) { return; }

        Value = Mathf.Clamp(Value + changeAmount, _minValue, _maxValue);

        _onValueChanged?.Invoke(Value);

        if (_minValue == Value)
        {
            _onMinValueReached?.Invoke();
        }

        if (_maxValue == Value)
        {
            _onMaxValueReached?.Invoke();
        }

    }

    public void SetMinimum()
    {
        Value = _minValue;
        _onMinValueReached?.Invoke();
    }

    public void SetMaximum()
    {
        Value = _maxValue;
        _onMaxValueReached?.Invoke();
    }

}
