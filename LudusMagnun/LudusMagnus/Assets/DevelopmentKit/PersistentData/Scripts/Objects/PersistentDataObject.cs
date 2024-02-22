using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEditor.Progress;

[CreateAssetMenu(fileName = "New Persistent Data", menuName = "Persistent Data System/New PersistentData", order = 1)]
public class PersistentDataObject : ScriptableObject
{
    public string path;
    public List<object> persistentData;

    public void Add()
    {

    }
    public void Save(string fileName = null)
    {
        ObjectHelper.SaveObject<List<object>>(path, persistentData);
    }

    public void Load(string fileName = null)
    {
        persistentData = ObjectHelper.GetObject<List<object>>(path);
    }
}
