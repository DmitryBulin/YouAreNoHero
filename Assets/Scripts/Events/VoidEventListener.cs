using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This is class to put on an object on scene
/// It listens to specific VoidEventChannelSO 
/// </summary>

public class VoidEventListener : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO _channel = default;
    [SerializeField] private UnityEvent _onEventRaised;

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

    public void Respond()
    {
        _onEventRaised?.Invoke();
    }

}
