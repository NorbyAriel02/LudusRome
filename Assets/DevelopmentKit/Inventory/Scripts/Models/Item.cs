[System.Serializable]
public class Item
{
    public string Name;
    public int Id = -1;
    public bool stackable;
    public int rowsHigh;
    public int columsWide;    
    public ItemType type;
    public ItemBuff[] buffs;
    private int x;
    private int y;
    public Item()
    {
        Name = "";
        Id = -1;
    }
    public Item(ItemObject item)
    {
        Name = item.name;
        Id = item.data.Id;
        stackable = item.data.stackable;
        rowsHigh = item.data.rowsHigh;
        columsWide = item.data.columsWide;
        x = item.data.x;
        y = item.data.y;        
        type = item.data.type;
        buffs = new ItemBuff[item.data.buffs.Length];
        for (int i = 0; i < buffs.Length; i++)
        {
            buffs[i] = new ItemBuff(item.data.buffs[i].Min, item.data.buffs[i].Max)
            {
                stat = item.data.buffs[i].stat
            };
        }
    }
    public int X { get { return x; } set { x = value; } }
    public int Y { get { return y; } set { y = value; } }
}
