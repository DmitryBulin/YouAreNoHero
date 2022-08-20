using UnityEngine;

/// <summary>
/// This class is to put on the object with class implementing IPausable interface
/// </summary>

[RequireComponent(typeof(IPausable))]
public class PausableMonitor : MonoBehaviour
{
    [SerializeField] private PausableSet _set;

    private void OnEnable()
    {
        foreach (IPausable pausable in GetComponents<IPausable>())
        {
            _set.Add(pausable);
        }
    }

    private void OnDisable()
    {
        foreach (IPausable pausable in GetComponents<IPausable>())
        {
            _set.Remove(pausable);
        }
    }

}
