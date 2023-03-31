using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

[System.Serializable]
public class Inventory
{    
    public InventorySlot[,] MatrixSlots;
    private int row = 6;
    private int col = 4;    
    public Inventory(int _row, int _col)
    {
        row= _row;
        col= _col;
        MatrixSlots = new InventorySlot[row, col];
        for (int x = 0; x < row; x++)
        {
            for (int y = 0; y < col; y++)
            {
                MatrixSlots[x, y] = new InventorySlot();
            }
        }
    }
    public InventorySlot[,] GetMatrixSlots()
    {  
        return MatrixSlots;
    }
    public InventorySlot GetSlot(int _row, int _col)
    {
        return MatrixSlots[_row,_col];
    }
    public void Clear()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0;j < col; j++)
            {
                MatrixSlots[i,j].item = new Item();
                MatrixSlots[i,j].amount = 0;
            }            
        }
    }
    public bool ContainsItem(ItemObject itemObject)
    {
        for(int x = 0; x < row; x++)
        {
            for(int y = 0; y < col; y++)
            {
                if (MatrixSlots[x,y].item.Id == itemObject.data.Id)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
}