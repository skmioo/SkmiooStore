using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ReferenceTool : MonoBehaviour,IDictionary<string,UnityEngine.Object>
{
    [SerializeField] public string group;
    [SerializeField] public List<string> keys = new List<string>();
    [SerializeField] public List<Object> values = new List<Object>();
    [SerializeField] public List<int> priority = new List<int>();

    public Object this[string key]
    {
        get
        {
            if (TryGetValue(key,out var value))
            {
                return value;
            }
            return null;
        }
        set
        {
            Add(key, value);
        }
    }

    public ICollection<string> Keys => keys;

    public ICollection<Object> Values => values;

    public int Count => keys.Count;

    public bool IsReadOnly => false;

    private int startingPoint = 0;

    public void Add(string key, Object value)
    {
        if (keys.Contains(key))
        {
            Debug.LogWarning($"Kye {key} 重复添加！");
        }
        else
        {
            keys.Add(key);
            values.Add(value);
        }
    }

    public void Add(KeyValuePair<string, Object> item)
    {
        Add(item.Key, item.Value);
    }


    public void Clear()
    {
        keys.Clear();
        values.Clear();
    }

    public bool Contains(KeyValuePair<string, Object> item)
    {
        return ContainsKey(item.Key);
    }

    public bool ContainsKey(string key)
    {
        return keys.Contains(key);
    }

    public void CopyTo(KeyValuePair<string, Object>[] array, int arrayIndex)
    {
        
    }

    public IEnumerator<KeyValuePair<string, Object>> GetEnumerator()
    {
        for (int index = 0; index < this.values.Count; index++)
        {
            int i = (index + startingPoint) % values.Count;
            yield return new KeyValuePair<string, Object>(keys[i], values[i]);
        }
    }

    public bool Remove(string key)
    {
        if (keys.Contains(key))
        {
            int i = keys.IndexOf(key);
            keys.RemoveAt(i);
            values.RemoveAt(i);
            return true;
        }
        return false;
    }

    public bool Remove(KeyValuePair<string, Object> item)
    {
        return Remove(item.Key);
    }

    public bool TryGetValue(string key, out Object value)
    {
        if (keys.Contains(key))
        {
            value = values[keys.IndexOf(key)];
            return true;
        }
        else
        {
            value = null;
            return false;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        for (int index = 0; index < this.values.Count; index++)
        {
            yield return values[(index + startingPoint) % values.Count];
        }
    }
}
