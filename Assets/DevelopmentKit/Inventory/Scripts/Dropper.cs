using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public InventoryObject inventory;
    public List<GameObject> droppedObjects;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D)) { 
            int index = Random.Range(0, inventory.database.ItemObjects.Length);
            GameObject go = Instantiate(droppedObjects[0], transform);
            go.GetComponent<GroundItem>().item = inventory.database.ItemObjects[index];
        }
    }
}
