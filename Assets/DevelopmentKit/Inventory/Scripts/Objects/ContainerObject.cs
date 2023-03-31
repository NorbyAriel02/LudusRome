using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(fileName = "New Container", menuName = "Inventory System/Container")]
public class ContainerObject : ScriptableObject
{
    public string savePath;
    public ItemDatabaseObject database;
    public InterfaceType type;
    protected Inventory Container;
    public int row;
    public int col;
    public ContainerObject()
    {
        Container = new Inventory(row, col);
    }
    public virtual InventorySlot GetSlot(GameObject go)
    {
        
        return null;
    }
    public virtual InventorySlot GetSlot(int x, int y)
    {
        
        return null;
    }
    public virtual bool AddItem(ItemObject itemObj, int amount)
    {
        Item item = itemObj.CreateItem();
        return AddItem(item, amount);
    }
    public virtual bool AddItem(Item item, int amount)
    {
        
        return true;
    }
    public virtual void ChangeItemLocation(Item item, int xSlot, int ySlot, int amount)
    {
       
    }
    public virtual void RemoveItem(Item item, int xSlot, int ySlot)
    {
        
    }
    protected virtual void ChangeStateSlot(Item item)
    {
        
    }
    protected virtual bool HasSpace(Item item)
    {
        

        return false;
    }
    /*Esto lo utilizo para buscar un espacio disponible en 
     el inventario, recoriendo todo hasta encontrar el espacio libre*/
    public virtual bool IsSpaceAvailable(Item item, int xMin, int yMin)
    {
        

        return true;
    }
    /*Esto lo utilizo cuando muevo un item en el inventario 
     y se que posicion quiero usar, es mas optimo*/
    public virtual bool IsSpaceAvailableReverse(Item item, int xSlot, int ySlot)
    {
        

        return true;
    }

    [ContextMenu("Save")]
    public void Save()
    {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, Container);
        stream.Close();
    }

    /* Cargamos los items desde el archivo a 
     * memorio en el objeto inventario */
    [ContextMenu("Load")]
    public virtual void Load()
    {
        
    }

    /*No se que hace este metodo*/
    [ContextMenu("Clear")]
    public void Clear()
    {
        Container.Clear();
    }
}
