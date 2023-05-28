using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ContainerModel 
{
    public Guid Id;
    public string name;
    public string description;
    public int Index;
    public int rows;
    public int columns;
    public List<ItemModel> items;
    public bool AddItem(ItemModel item)
    {
        #region cometario
        //validar si hay espacion en el contenedor
        //agregar el item a la lista de items
        //retornar si true si se agrego, false si no se agrego
        #endregion
        if (items.Count >= rows * columns)
            return false;

        items.Add(item);

        return true;
    }

    public void RemoveItem(ItemModel itemToRemove)
    {
        foreach (ItemModel item in items)
        {
            if (item.Id == itemToRemove.Id)
            {
                items.Remove(item);
                return;
            }
        }
    }
}
