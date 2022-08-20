using UnityEngine;

public class LocalOrbiting : MonoBehaviour
{

    private void Awake()
    {
        transform.localPosition = Vector2.down;
    }


    public void ChangePosition(Vector2 newPosition)
    {
        transform.localPosition = newPosition.normalized;
    }

}
