using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class DataBaseObject : ScriptableObject
{
    public List<GenericObject> objs = new List<GenericObject>();
    public void OnValidate()
    {
        AsignIndex();
    }
    public void OnEnable()
    {
        AsignIndex();
    }
    private void AsignIndex()
    {
        for (int i = 0; i < objs.Count; i++)
        {
            objs[i].Index = i;
        }
    }
}
