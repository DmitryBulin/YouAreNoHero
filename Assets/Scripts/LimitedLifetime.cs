using System.Collections;
using UnityEngine;

/// <summary>
/// This class is to put on the object to make it expire over time
/// </summary>

public class LimitedLifetime : MonoBehaviour
{
    [Tooltip("It takes the maximum value of the variable")]
    [SerializeField] private FloatVariable _lifeTime = default;

    private void OnEnable()
    {
        StartCoroutine(TickDown());
    }

    private IEnumerator TickDown()
    {
        float time = _lifeTime.MaximumValue;
        
        while (time > 0f)
        {
            time -= Time.deltaTime;
            yield return null;
        }

        // TODO: Return to the pool via turning off, rather than destroying
        Destroy(gameObject);
    }

}
