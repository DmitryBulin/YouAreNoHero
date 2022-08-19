using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This is class to put on an object on scene
/// It listens to specific Vector2EventChannelSO 
/// </summary>

public class Vector2EventListener : MonoBehaviour
{
    [SerializeField] private Vector2EventChannelSO _channel = default;
    [SerializeField] private UnityEvent<Vector2> _onEventRaised;

    private void OnEnable()
    {
        if (_channel != null)
        {
            _channel.OnEventRaised += Respond;
        }
    }

    private void OnDisable()
    {
        if (_channel != null)
        {
            _channel.OnEventRaised -= Respond;
        }
    }

    public void Respond(Vector2 variable)
    {
        _onEventRaised?.Invoke(variable);
    }

}
