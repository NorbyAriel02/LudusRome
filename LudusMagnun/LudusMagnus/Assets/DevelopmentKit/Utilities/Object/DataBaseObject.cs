using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DataBaseObject : ScriptableObject
{
    public List<GenericObject> objs = new List<GenericObject>();
    public void OnValidate()
    {
        for (int i = 0; i < objs.Count; i++)
        {
            objs[i].Index = i;
        }        
    }
}
