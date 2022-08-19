using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Event channel with zero arguments
/// </summary>

[CreateAssetMenu(menuName = "Events / Void Event")]
public class VoidEventChannelSO : ScriptableObject
{
    public event UnityAction OnEventRaised = delegate { };

    public void Invoke()
    {
        OnEventRaised.Invoke();
    }

}
