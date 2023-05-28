
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class ContainerUserInterface : MonoBehaviour
{
    //public Vector2 SlotSize;
    public Vector2 itemSize;
    public ItemDataBaseObject DBItems;
    public List<GameObject> Slots;
    protected void OnEnable()
    {                
        EnableUI();
    }
    protected void OnDisable()
    {     
        DisableUI();
    }
    protected void OnDestroy()
    {
        DestroyUI();
    }
    protected virtual void EnableUI()
    {

    }
    protected virtual void DisableUI()
    {

    }
    protected virtual void DestroyUI()
    {

    }
    public virtual void RemoveItem(GameObject item)
    {

    }
    public virtual bool AddItem(GameObject item)
    {
        return false;
    }
    public virtual void ShowItemsToInventory()
    {        
        
    }
    protected virtual void ShowItemsToInventory(int index)
    {
        
    }
    protected GameObject CreateItemUIDisplay(int index)
    {
        ItemObject itemObject = (ItemObject)DBItems.objs[index];
        GameObject itemGO = ObjectHelper.CreateImageForUI(itemObject.name, itemObject.sprite, false);        
        return itemGO;
    }
    protected void LinkItemWithSlot(GameObject slotGO, ItemModel item, GameObject itemGO, Vector2 cellSize)
    {
        itemGO.transform.SetParent(slotGO.transform, false);
        Slot slot = slotGO.GetComponent<Slot>();
        item.Row = slot.row;
        item.Col = slot.col;
        RectTransform rt = itemGO.GetComponent<RectTransform>();
        rt.sizeDelta = cellSize;
        slot.isEmpty = false;
        Item itemComponent = itemGO.AddComponent<Item>();
        itemComponent.data = item;
    }
    protected GameObject GetSpecificSlot(int row, int column)
    {
        foreach (GameObject slot in Slots)
        {
            Slot slotComponent = slot.GetComponent<Slot>();
            if (slotComponent.row == row && slotComponent.col == column)
                return slot;
        }
        return null;
    }
    protected GameObject GetEpmtySlot()
    {
        foreach (GameObject item in Slots)
        {
            Slot slot = item.GetComponent<Slot>();
            if (slot.isEmpty)
                return item;
        }
        return null;
    }
    protected GameObject GetSlot(ItemModel item)
    {
        GameObject slotGO;
        if (item.Row == -1)
            slotGO = GetEpmtySlot();
        else
            slotGO = GetSpecificSlot(item.Row, item.Col);

        return slotGO;
    }
    protected void DefaultSlotConfiguration(GameObject slotGO, int index, int row, int col)
    {
        //RectTransform rt = slotGO.GetComponent<RectTransform>();
        //rt.sizeDelta = SlotSize;
        #region comentario
        /*En esta parte agrego el componente [Slot] al 
                 * objecto slot para configurar los valores como 
                 * numero de fila y columna del slot e index 
                 * y marcar que esta vacio por default, 
                 * mas adelante en el proceso se asocia 
                 * el slot con un item existente en el 
                 * inventario en caso de que dicho item exista*/
        #endregion
        Slot slotComponent = slotGO.GetComponent<Slot>();

        if (slotComponent == null)
            slotComponent = slotGO.AddComponent<Slot>();

        slotComponent.row = row;
        slotComponent.col = col;
        slotComponent.index = index;
        slotComponent.isEmpty = true;       
    }    
}
