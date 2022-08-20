using UnityEngine;

public class LocalOrbiting : MonoBehaviour
{
    [SerializeField] private FloatVariable _offset;

    private void Awake()
    {
        transform.localPosition = _offset.MaximumValue * Vector2.down;
    }


    public void ChangePosition(Vector2 newPosition)
    {
        if (newPosition.Equals(Vector2.zero)) { return; }
        transform.localPosition = _offset.MaximumValue * newPosition;
    }

}
