using UnityEngine;

/// <summary>
/// This class broadcasts its' object position every fixed update
/// </summary>

public class PositionBroadcaster : MonoBehaviour
{
    [SerializeField] private Vector2EventChannelSO _channel;
    [SerializeField] private bool _localPosition;

    private Vector2 _broadcastPosition;

    void FixedUpdate()
    {
        _broadcastPosition.x = _localPosition ? transform.localPosition.x : transform.position.x;
        _broadcastPosition.y = _localPosition ? transform.localPosition.y : transform.position.y;
        _channel.Invoke(_broadcastPosition);
    }
}
