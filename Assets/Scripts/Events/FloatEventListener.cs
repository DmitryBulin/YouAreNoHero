using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This is class to put on an object on scene
/// It listens to specific FloatEventChannelSO 
/// </summary>

public class FloatEventListener : MonoBehaviour
{
    [SerializeField] private FloatEventChannelSO _channel = default;
    [SerializeField] private UnityEvent<float> _onEventRaised;

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

    public void Respond(float variable)
    {
        _onEventRaised?.Invoke(variable);
    }

}
