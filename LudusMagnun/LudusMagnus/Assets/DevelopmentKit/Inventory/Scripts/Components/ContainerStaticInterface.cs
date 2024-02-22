using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerStaticInterface : ContainerUserInterface
{
    public ContainerObject InventorySO;
    protected override void EnableUI()
    {
        InventorySO.Load();
        SetSlots();
        ShowItemsToInventory();        
    }
    protected override void DisableUI()
    {
        InventorySO.Save();
        ChildrenController.RemoveAllChildren(gameObject);
    }
    protected override void DestroyUI()
    {
        InventorySO.Save();
    }
    public override bool AddItem(GameObject itemGO)
    {
        ItemModel itemModel = itemGO.GetComponent<Item>().data;
        return InventorySO.AddItem(itemModel);
    }
    public override void RemoveItem(GameObject itemGO)
    {
        ItemModel itemModel = itemGO.GetComponent<Item>().data;
        InventorySO.RemoveItem(itemModel);
    }
    public override void ShowItemsToInventory()
    {
        foreach (ItemModel item in InventorySO.items)
        {
            GameObject itemGO = CreateItemUIDisplay(item.index);
            LinkItemWithSlot(GetSlot(item), item, itemGO, itemSize);
        }
    }
    private void SetSlots()
    {
        /*Las dimenciones salen del scriptableObject contenedor al
         que se hace referencia en este componente*/
        int count = 0;
        for (int row = 0; row < InventorySO.rows; row++)//rows
        {
            for (int col = 0; col < InventorySO.columns; col++)//columns
            {
                GameObject slotGameObject = Slots[count].gameObject;
                DefaultSlotConfiguration(slotGameObject, count, row, col);
                count++;
            }
        }
    }
}
