using System.Collections.Generic;
using UnityEngine;

public class ExpDropManager : Singleton<ExpDropManager>
{
    public List<GameObject> expDrops;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ClearList();
    }

    public void AddExpToList(GameObject _drop)
    {
        expDrops.Add(_drop);
    }

    public void RemoveExpToList(GameObject _drop)
    {
        if (expDrops.Count == 0) return;
        expDrops.Remove(_drop);
        Destroy(_drop);
    }

    public void ClearList()
    {
        if (expDrops.Count == 0) return;
        foreach (GameObject _drop in expDrops)
        { Destroy(_drop); }
        expDrops.Clear();
    }
}
