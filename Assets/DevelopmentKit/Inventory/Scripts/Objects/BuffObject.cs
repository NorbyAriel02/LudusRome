using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item Buff", menuName = "Inventory System/Items/New Item Buff", order = 4)]
public class BuffObject : GenericObject
{
    public AttributeObject attribute;
    public float value = 0;
    public float minValue = 0;
    public float maxValue = 0;

    public float GetValue(int lvl)
    {
        if(value == 0)
        {
            float val = Random.Range(minValue, maxValue);
            return Formulas.GetValueAttributeForLevel(lvl, val);
        }        
        return value;
    }

    public BuffModel Create(int lvl)
    {
        BuffModel model = new BuffModel();
        model.value = GetValue(lvl);
        model.abbreviation = attribute.name;
        model.name = name;
        return model;
    }
}
