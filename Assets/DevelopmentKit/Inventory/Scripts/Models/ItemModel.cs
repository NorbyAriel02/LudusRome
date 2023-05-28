using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemModel
{
    public Guid Id;
    public string name;
    [TextArea(2, 5)]
    public string description;
    public int level;
    public int index;
    public bool stackable;    
    public int rowsHigh = 1;
    public int columsWide = 1;
    public List<BuffModel> Buffs;    
    private int row = -1;
    private int col = -1;
    public int Row { get { return row; } set { row = value; } }
    public int Col { get { return col; } set { col = value; } }
    public ItemModel()
    {
        Buffs = new List<BuffModel>();
    }    
}