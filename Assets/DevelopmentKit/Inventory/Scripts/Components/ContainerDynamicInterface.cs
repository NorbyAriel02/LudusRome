using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class ContainerDynamicInterface : ContainerUserInterface
{
    public ContainerObject InventorySO;
    public Sprite spriteSlot;
    protected override void EnableUI()
    {
        InventorySO.Load();
        OpenInventory();
    }
    protected override void DisableUI()
    {
        CloseInventory();
    }
    protected override void DestroyUI()
    {
        InventorySO.Save();
    }
    public override void RemoveItem(GameObject itemGO)
    {
        ItemModel itemModel = itemGO.GetComponent<Item>().data;
        InventorySO.RemoveItem(itemModel);
    }
    public override bool AddItem(GameObject itemGO)
    {
        ItemModel itemModel = itemGO.GetComponent<Item>().data;
        return InventorySO.AddItem(itemModel);
    }
    public override void ShowItemsToInventory()
    {
        foreach (ItemModel item in InventorySO.items)
        {
            GameObject itemGO = CreateItemUIDisplay(item.index);
            LinkItemWithSlot(GetSlot(item), item, itemGO, itemSize);
        }
    }
    public void OpenInventory()
    {
        GenerateGameObjectSlots();
        if (Slots != null)
            Slots.Clear();
        Slots = ChildrenController.GetListChildren(gameObject);
        ShowItemsToInventory();
    }
    public void CloseInventory()
    {
        ChildrenController.RemoveAllChildren(gameObject);
    }
    private void GenerateGameObjectSlots()
    {
        /*Las dimenciones salen del scriptableObject contenedor al
         que se hace referencia en este componente*/
        int count = 0;
        for (int row = 0; row < InventorySO.rows; row++)//rows
        {
            for (int col = 0; col < InventorySO.columns; col++)//columns
            {                
                GameObject slotGameObject = ObjectHelper.CreateImageForUI("slot"+row+col, spriteSlot, true, transform);
                DefaultSlotConfiguration(slotGameObject, count, row, col);
                count++;
            }
        }
    }    
}
