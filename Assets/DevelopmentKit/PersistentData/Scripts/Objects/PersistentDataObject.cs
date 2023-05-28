using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Persistent Data", menuName = "Persistent Data System/New PersistentData", order = 1)]
public class PersistentDataObject : ScriptableObject
{
    public List<ScriptableObject> persistentData;
    public void Save(string fileName = null)
    {
        
    }

    public void Load(string fileName = null)
    { 
        
    }
}
