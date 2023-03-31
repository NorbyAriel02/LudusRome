using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
public class InventoryObject : ContainerObject
{
    public override InventorySlot GetSlot(GameObject go)
    {
        for (int x = 0; x < row; x++)
        {
            for (int y = 0; y < col; y++)
            {                
                if(Container.MatrixSlots[x, y].slotDisplay == go)
                {
                    return Container.MatrixSlots[x, y];
                }                    
            }
        }
        return null;
    }
    public override InventorySlot GetSlot(int x, int y)
    {
        if(x < 0 || y < 0 || x >= row || y >= col)
            return null;

        return Container.MatrixSlots[x, y];
    }
    public override bool AddItem(ItemObject itemObj, int amount)
    {
        Item item = itemObj.CreateItem();
        return AddItem(item, amount);
    }
    public override bool AddItem(Item item, int amount)
    {
        if (!HasSpace(item))
            return false;

        Container.MatrixSlots[item.X, item.Y].UpdateSlot(item, amount);
        ChangeStateSlot(item);
        return true;
    }
    public override void ChangeItemLocation(Item item, int xSlot, int ySlot, int amount)
    {
        item.X = xSlot;
        item.Y = ySlot;
        Container.MatrixSlots[xSlot, ySlot].UpdateSlot(item, amount);
        ChangeStateSlot(item);
    }    
    public override void RemoveItem(Item item, int xSlot, int ySlot)
    {
        Container.MatrixSlots[xSlot, ySlot].UpdateSlot(new Item(), 0);
        ChangeStateSlot(item);
    }
    protected override void ChangeStateSlot(Item item)
    {
        int xMin = item.X - (item.rowsHigh - 1);
        int yMin = item.Y - (item.columsWide - 1);

        for (int x = xMin; x <= item.X; x++)
        {
            for (int y = yMin; y <= item.Y; y++)
            {
                Container.MatrixSlots[x, y].empty = !Container.MatrixSlots[x, y].empty;
            }
        }
    }
    protected override bool HasSpace(Item item)
    {        
        for (int x = 0; x < row; x++)
        {
            for (int y = 0; y < col; y++)
            {                
                item.X = x + (item.rowsHigh - 1);                
                item.Y = y + (item.columsWide - 1);
                if (IsSpaceAvailable(item, x, y))
                {
                    return true;
                }
            }
        }

        return false;
    }        
    /*Esto lo utilizo para buscar un espacio disponible en 
     el inventario, recoriendo todo hasta encontrar el espacio libre*/
    public override bool IsSpaceAvailable(Item item, int xMin, int yMin)
    {
        if (!Container.MatrixSlots[xMin, yMin].empty)
            return false;

        if (item.X >= row || item.Y >= col)
            return false;

        for (int x = xMin; x <= item.X; x++)
        {
            for (int y = yMin; y <= item.Y; y++)
            {
                if (!Container.MatrixSlots[x, y].empty)
                    return false;
            }
        }

        return true;
    }
    /*Esto lo utilizo cuando muevo un item en el inventario 
     y se que posicion quiero usar, es mas optimo*/
    public override bool IsSpaceAvailableReverse(Item item, int xSlot, int ySlot)
    {
        if (!Container.MatrixSlots[xSlot, ySlot].empty)
            return false;

        int xMin = xSlot - (item.rowsHigh - 1);
        int yMin = ySlot - (item.columsWide - 1);

        if (xMin > row || yMin > col || xMin < 0 || yMin < 0)
            return false;

        for (int x = xSlot; x >= xMin; x--)
        {
            for (int y = ySlot; y >= yMin; y--)
            {
                if (!Container.MatrixSlots[x, y].empty)
                    return false;
            }
        }

        return true;
    }            


    /* Cargamos los items desde el archivo a 
     * memorio en el objeto inventario */
    [ContextMenu("Load")]
    public override void Load()
    {        
        if (File.Exists(string.Concat(Application.persistentDataPath, savePath)))
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Open, FileAccess.Read);
            Container = (Inventory)formatter.Deserialize(stream);
            stream.Close();
        }
        else
        {
            Container = new Inventory(row, col);
        }
        /*Correccion para cambios en edicio*/
        #if UNITY_EDITOR
            int count = row*col;
            if(Container.MatrixSlots.Length != count)
            {
                Container = new Inventory(row, col);
            }
        #endif
    }

}

