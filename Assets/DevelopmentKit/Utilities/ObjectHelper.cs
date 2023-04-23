using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectHelper 
{
    public static List<GameObject> GetPull(GameObject prefab, int count, Transform parent)
    {
        List<GameObject> list = new List<GameObject>();
        for(int i = 0; i < count;i++)
        {
            GameObject go = UnityEngine.Transform.Instantiate(prefab, parent);
            go.SetActive(false);
            list.Add(go);
        }
        return list;
    }
}
