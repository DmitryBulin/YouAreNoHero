using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Event channel with Vector2 argument
/// </summary>

[CreateAssetMenu(menuName = "Events / Vector2 Event")]
public class Vector2EventChannelSO : ScriptableObject
{
    public event UnityAction<Vector2> OnEventRaised = delegate { };

    public void Invoke(Vector2 value)
    {
        OnEventRaised.Invoke(value);
    }

}
