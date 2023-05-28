using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenData : MonoBehaviour
{
    List<PersistentDataObject> data;
    public void OnEnable()
    {
        foreach (PersistentDataObject obj in data)
        {
            
        }
    }
    public void OnDestroy()
    {
        
    }
}
