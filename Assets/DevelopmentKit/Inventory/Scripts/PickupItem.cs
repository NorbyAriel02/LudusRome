using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class PickupItem : MonoBehaviour
{    
    public UserInterface uiInventory;
    public InventoryObject inventory;
    private Item item;
    private void Awake()
    {
        uiInventory = (UserInterface)FindObjectOfType(typeof(UserInterface));
        item = GetComponent<GroundItem>().item.CreateItem();
    }

    private void OnMouseDown()
    {  
        if (uiInventory != null && uiInventory.isActiveAndEnabled)
        {
            if (uiInventory.CreateItemToMouse(item))
                Destroy(gameObject);
        }
        else
        {
            if(inventory.AddItem(item, 1))
                Destroy(gameObject);
        }
    }
}
