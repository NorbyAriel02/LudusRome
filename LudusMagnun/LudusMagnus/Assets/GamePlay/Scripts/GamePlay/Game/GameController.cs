using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public string pathEquipment = "/equipamiento.save";
    void Start()
    {
        //DynamicInventories.Load(pathEquipment);
    }

    private void OnDestroy()
    {
        //DynamicInventories.Save(pathEquipment);
    }
}
