using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class InventoryEventes : MonoBehaviour
{
    public ItemDataBaseObject dbItems;
    private GameObject father;
    private void Start()
    {
        father = ObjectHelper.GetParentWithComponent<Canvas>(gameObject);
    }
    private void OnEnable()
    {
        Slot.OnMoveItem += MoveItem;
        Slot.OnRecieveItem += ReceiveItem;
    }
    private void OnDisable()
    {
        Slot.OnMoveItem -= MoveItem;
        Slot.OnRecieveItem -= ReceiveItem;
    }
    private void FixedUpdate()
    {        
        if(MouseData.item != null)
        {
            MouseData.rectItem.position = new Vector3((Input.mousePosition.x - (MouseData.rectItem.sizeDelta.x / 2)), (Input.mousePosition.y + (MouseData.rectItem.sizeDelta.y / 2)), Input.mousePosition.z);
        }
    }
    private bool ReceiveItem(Slot slot)
    {
        if (MouseData.item == null)
            return false;

        if (!ValidateType(MouseData.itemModel, slot))
            return false;

        MouseData.item.transform.SetParent(slot.transform);
        MouseData.rectItem.localPosition = Vector3.zero;
        MouseData.itemModel.Row = slot.row;
        MouseData.itemModel.Col = slot.col;


        MouseData.item = null;
        MouseData.rectItem = null;
        MouseData.itemModel = null;
        return true;
    }
    private void MoveItem(GameObject item)
    {
        item.transform.SetParent(father.transform);
        MouseData.item = item;
        MouseData.itemModel = MouseData.item.GetComponent<Item>().data;
        MouseData.rectItem = MouseData.item.GetComponent<RectTransform>();
    }
    private bool ValidateType(ItemModel item, Slot slot)
    {
        if (slot.types == null || slot.types.Count <= 0)
            return true;

        ItemObject io = (ItemObject)dbItems.objs[item.index];
        return slot.types.Contains(io.type);
    }
}
