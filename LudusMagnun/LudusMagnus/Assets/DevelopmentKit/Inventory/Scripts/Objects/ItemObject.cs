using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Items/New Item", order = 1)]
public class ItemObject : GenericObject
{    
    public int level;
    public bool stackable;
    public int rowsHigh = 1;
    public int columsWide = 1;
    public Sprite sprite;
    public GameObject itemDisplay;
    public ItemTypeObject type;
    public List<BuffObject> buffs;
 
    public ItemModel Create(int lvl = 1)
    {
        #region descripcion
        /*con este metodo creo una instancia unica de item, 
         * este itemModel puede persistir a lo largo del 
         * juego al ser guardado por el contenedor con su 
         * metodo save, hay datos que no puede ser serealizados 
         * para guardarce con este metodo y es bueno porque 
         * estariamos serializando y guardando tipos de datos 
         * muy pesados, informacion que no tenemos que duplicar, 
         * como imagenes*/
        #endregion
        ItemModel model = new ItemModel();
        model.Id = Guid.NewGuid();
        model.level = lvl;
        model.name = name;
        model.description = description;
        model.stackable = stackable;
        model.rowsHigh = rowsHigh;
        model.columsWide = columsWide;
        model.index = Index;
        
        foreach (BuffObject buff in buffs)
        {            
            BuffModel buffModel = buff.Create(lvl);
            model.Buffs.Add(buffModel);
        }        
        
        return model;
    }
}
