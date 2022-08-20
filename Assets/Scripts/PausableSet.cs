using UnityEngine;

/// <summary>
/// This class holds objects that implements IPausable interface
/// </summary>

[CreateAssetMenu(menuName = "Data / Pausable Set")]
public class PausableSet : RuntimeSet<IPausable>
{
    public void Pause()
    {
        foreach (IPausable pausable in Items)
        {
            pausable.Pause();
        }
    }

    public void Unpause()
    {
        foreach (IPausable pausable in Items)
        {
            pausable.Unpause();
        }
    }

}
