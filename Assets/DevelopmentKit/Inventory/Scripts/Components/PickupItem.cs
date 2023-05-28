using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public ItemObject ItemObj;
    private Item item;
    private ContainerDynamicInterface containerUserInterface;
    void Start()
    {
        item = GetComponent<Item>();
        item.data = ItemObj.Create();
        containerUserInterface = GameObject.FindObjectOfType<ContainerDynamicInterface>();
    }
    private void OnMouseOver()
    {
        if(Input.GetMouseButton(0))
        {
            if (containerUserInterface.AddItem(gameObject))
            {
                containerUserInterface.ShowItemsToInventory();
                Destroy(gameObject);
            }
                
        }
    }
}
