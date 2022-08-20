using System.Collections.Generic;
using UnityEngine;

public abstract class RuntimeSet<T> : ScriptableObject
{
    public List<T> Items = new List<T>();

    public void Add(T newItem)
    {
        if (!Items.Contains(newItem))
        {
            Items.Add(newItem);
        }
    }

    public void Remove(T newItem)
    {
        if (Items.Contains(newItem))
        {
            Items.Remove(newItem);
        }
    }

}
