using System.Collections.Generic;
using UnityEngine;

public class DropManager : Singleton<DropManager>
{
    public List<GameObject> dropList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ClearList();
    }

    public void AddDropToList(GameObject _drop)
    {
        dropList.Add(_drop);
    }

    public void RemoveDropToList(GameObject _drop)
    {
        if (dropList.Count == 0) return;
        dropList.Remove(_drop);
        Destroy(_drop);
    }

    public void ClearList()
    {
        if (dropList.Count == 0) return;
        foreach (GameObject _drop in dropList)
        { Destroy(_drop); }
        dropList.Clear();
    }
}
