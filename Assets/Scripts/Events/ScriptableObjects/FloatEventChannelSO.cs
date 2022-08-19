using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Event channel with single float argument
/// </summary>

[CreateAssetMenu(menuName = "Events / Float Event")]
public class FloatEventChannelSO : ScriptableObject
{
    public event UnityAction<float> OnEventRaised = delegate { };

    public void Invoke(float value)
    {
        OnEventRaised.Invoke(value);
    }

}
