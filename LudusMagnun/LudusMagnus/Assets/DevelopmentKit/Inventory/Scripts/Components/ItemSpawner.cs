using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("Para Reiniciar el contenedor en cada ejecucion")]
    public bool reset;
    [Header("Para crear items en el inventario")] 
    public bool ItemsToContainer;
    [Header("Para crear items en el Mundo del juego")]
    public bool ItemsToWorld;
    public List<ContainerObject> containersObject;
    //public ContainerListObject containersListObject;
    public List<ItemObject> itemObjects;
    private List<ContainerModel> containersModel;
    private void Awake()
    {
        
    }
    private void OnEnable()
    {
        if (reset)
        {
            ResetContainer();
        }
        if (ItemsToWorld)
        {
            CreateItemsToWorld();
        }
        if (ItemsToContainer)
        {
            foreach (ContainerObject container in containersObject)
            {
                container.Load();
                CreateItemsToInventory(container);
                container.Save();
            }
        }
    }
    public void CreateItemsToWorld(Vector3 pos = new Vector3(), Quaternion rot = new Quaternion())
    {
        foreach (var itemObject in itemObjects)
        {
            CreateItemToWorld(itemObject, pos, rot);
        }
    }
    public void CreateItemToWorld(ItemObject itemObject, Vector3 pos = new Vector3(), Quaternion rot = new Quaternion())
    {
        GameObject go = Instantiate(itemObject.itemDisplay, pos, rot);
        Item itemComponent = go.AddComponent<Item>();
        itemComponent.data = itemObject.Create(itemObject.level);
    }
    //public void CreateItemsToEquipmentList()
    //{
    //    int index = Random.Range(0, containersListObject.Containers.Count);
    //    ContainerModel cm = containersListObject.Containers[index];
    //    foreach (ItemObject itemObject in itemObjects)
    //        cm.AddItem(itemObject.Create());
    //}
    //public void CreateContainer()
    //{
    //    ContainerModel containerModel = containersListObject.Create();
    //    containersListObject.AddContainer(containerModel);
    //}
    public void CreateItemsToInventory(ContainerObject container)
    {
        foreach (ItemObject itemObject in itemObjects)
            container.AddItem(itemObject.Create());
    }

    public void ResetContainer()
    {
        for(int i = 0; i < containersObject.Count; i++)
        {
            containersObject[i].Clear();
            containersObject[i].Save();
        }        
    }
}
