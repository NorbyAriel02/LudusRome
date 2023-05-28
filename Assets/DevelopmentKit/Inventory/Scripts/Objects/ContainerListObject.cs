using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New ContainerList", menuName = "Inventory System/Containers/ContainerList")]
public class ContainerListObject : GenericObject
{
    public string path;
    public ContainerObject containerTemplate;
    public List<ContainerModel> Containers;

    private void OnEnable()
    {
        Load();
    }
    private void OnDisable()
    {
        Save();
    }
    public ContainerModel Create()
    {
        ContainerModel model = new ContainerModel();
        model.Id = Guid.NewGuid();
        model.name = name;
        model.description = description;
        model.Index = Index;        
        model.rows = containerTemplate.rows;
        model.columns = containerTemplate.columns;
        model.items = new List<ItemModel>();
        
        return model;
    }

    public bool AddContainer(ContainerModel container)
    {
        if(Containers == null)
            Containers = new List<ContainerModel>();

        Containers.Add(container);

        return true;
    }

    public void RemoveItem(ContainerModel containerToRemove)
    {
        foreach (ContainerModel container in Containers)
        {
            if (container.Id == containerToRemove.Id)
            {
                Containers.Remove(container);
                return;
            }
        }
    }
    public void Load()
    {
        Containers = (List<ContainerModel>)ObjectHelper.GetObject<List<ContainerModel>>(path);
        if (Containers == null)
            Containers = new List<ContainerModel>();
    }

    public void Save()
    {
        ObjectHelper.SaveObject<List<ContainerModel>>(path, Containers);
    }
    /* Si estoy haciendo pruebas del inventario y
     * este se llena de item y necesito vaciarlo 
     * puede usar este metodo desde el menu de 
     * contexto del editor de unity*/
    [ContextMenu("Clear")]
    public void Clear()
    {
        Containers.Clear();
    }
}
