using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class ContainerListStaticInterface : ContainerUserInterface
{       
    public ContainerListObject containersList;
    private int currentContainer;    
    protected override void EnableUI()
    {
        SetSlots();
        ShowItemsToInventory(0);
    }
    protected override void DisableUI()
    {
        
    }
    protected override void DestroyUI()
    {
        containersList.Save();
    }
    public override void RemoveItem(GameObject itemGO)
    {
        ItemModel itemModel = itemGO.GetComponent<Item>().data;
        containersList.Containers[currentContainer].RemoveItem(itemModel);
    }
    public override bool AddItem(GameObject itemGO)
    {
        ItemModel itemModel = itemGO.GetComponent<Item>().data;
        return containersList.Containers[currentContainer].AddItem(itemModel);
    }
    protected override void ShowItemsToInventory(int index)
    {
        currentContainer = index;
        if (containersList.Containers.Count <= index)
        {
            Debug.LogWarning("No hay contenedor con el index " + index);
            foreach(var slot in Slots)
            {
                slot.SetActive(false);
            }
            return;
        }

        foreach (ItemModel item in containersList.Containers[index].items)
        {
            GameObject itemGO = CreateItemUIDisplay(item.index);            
            LinkItemWithSlot(GetSlot(item), item, itemGO, itemSize);
        }
    }
    public void SetSlots()
    {
        /*Las dimenciones salen del scriptableObject contenedor al
         que se hace referencia en este componente*/
        int count = 0;
        for (int row = 0; row < containersList.containerTemplate.rows; row++)//rows
        {
            for (int col = 0; col < containersList.containerTemplate.columns; col++)//columns
            {
                Slots[count].gameObject.SetActive(true);
                GameObject slotGameObject = Slots[count].gameObject;
                ChildrenController.RemoveAllChildren(slotGameObject);
                DefaultSlotConfiguration(slotGameObject, count, row, col);
                count++;
            }
        }
    }
    public void NextContainer()
    {
        currentContainer++;
        if (currentContainer >= containersList.Containers.Count)
        {
            currentContainer--;            
        }            
        ShowItemsToInventory(currentContainer);
    }
    public void PrevContainer()
    {
        currentContainer--;
        if (currentContainer < 0)
        {
            currentContainer++;            
        }
        ShowItemsToInventory(currentContainer);
    }
    public void CreateNewContainer()
    {
        currentContainer = containersList.Containers.Count;//Para que nos pocisione en el ultimo contenedor
        ContainerModel containerModel = containersList.Create();
        containersList.AddContainer(containerModel);
    }
    public void RemoveContainer()
    {
        int index = 0;
        if (currentContainer == 0)
            index = 0;
        else
            index = currentContainer - 1;

        ContainerModel containerModel = containersList.Containers[currentContainer];
        containersList.RemoveItem(containerModel);
        currentContainer = index;
    }    
}
