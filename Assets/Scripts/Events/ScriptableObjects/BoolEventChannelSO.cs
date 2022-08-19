using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Event channel with bool argument
/// </summary>

[CreateAssetMenu(menuName = "Events / Bool Event")]
public class BoolEventChannelSO : ScriptableObject
{
    public event UnityAction<bool> OnEventRaised = delegate { };

    public void Invoke(bool value)
    {
        OnEventRaised.Invoke(value);
    }

}
