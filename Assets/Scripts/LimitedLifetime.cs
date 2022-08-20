using System.Collections;
using UnityEngine;

/// <summary>
/// This class is to put on the object to make it expire over time
/// </summary>

public class LimitedLifetime : MonoBehaviour, IPausable
{
    [SerializeField] private FloatVariable _lifeTime = default;

    private bool _isPaused;

    public void Pause()
    {
        _isPaused = true;
    }

    public void Unpause()
    {
        _isPaused = false;
    }

    private void OnEnable()
    {
        StartCoroutine(TickDown());
    }

    private IEnumerator TickDown()
    {
        float time = _lifeTime.Value;
        
        while (time > 0f)
        {
            if (!_isPaused)
            {
                time -= Time.deltaTime;
            }
            yield return null;
        }

        // TODO: Return to the pool via turning off, rather than destroying
        Destroy(gameObject);
    }

}
