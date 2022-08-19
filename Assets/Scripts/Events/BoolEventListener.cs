using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This is class to put on an object on scene
/// It listens to specific BoolEventChannelSO 
/// </summary>

public class BoolEventListener : MonoBehaviour
{
    [SerializeField] private BoolEventChannelSO _channel = default;
    [SerializeField] private UnityEvent<bool> _onEventRaised;

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

    public void Respond(bool variable)
    {
        _onEventRaised?.Invoke(variable);
    }

}
