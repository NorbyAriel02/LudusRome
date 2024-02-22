using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistenData : MonoBehaviour
{
    public PersistentDataObject data;
    public void OnEnable()
    {
        data.Load();
    }
    public void OnDestroy()
    {
        data.Save();
    }
}
