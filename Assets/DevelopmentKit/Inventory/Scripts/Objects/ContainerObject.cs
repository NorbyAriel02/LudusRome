using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
[CreateAssetMenu(fileName = "New Container", menuName = "Inventory System/Containers/Container")]
public class ContainerObject : GenericObject
{    
    public string path;
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
    public void Load()
    {
        items = (List<ItemModel>)ObjectHelper.GetObject<List<ItemModel>>(path);
        if (items == null)
            items = new List<ItemModel>();
    }

    public void Save()
    {
        ObjectHelper.SaveObject<List<ItemModel>>(path, items);
    }
    /* Si estoy haciendo pruebas del inventario y
     * este se llena de item y necesito vaciarlo 
     * puede usar este metodo desde el menu de 
     * contexto del editor de unity*/
    [ContextMenu("Clear")]
    public void Clear()
    {
        items.Clear();
    }
}
