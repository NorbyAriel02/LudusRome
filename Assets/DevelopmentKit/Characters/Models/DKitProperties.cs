using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

[System.Serializable]
public class DKitProperties 
{    
    public List<DKitProperty> Properties;
    public void Create()
    {
        foreach (var prop in Properties)
        {
            int val = (int)UnityEngine.Random.Range(prop.minValue, prop.maxValue);
            prop.value = (val != 0) ? val : prop.value;     
            SetPropertyValue(prop.attribute, prop.value);
        }
    }    
    public void SetPropertyValue(Attributes attribute, float value)
    {
        DKitProperty foundProperty = Properties.Find(property => property.attribute == attribute);
        if(foundProperty == null)
        {            
            foundProperty.attribute = attribute;
            foundProperty.value = value;
            Properties.Add(foundProperty);
        }
        foundProperty.value = (float)value;
    }
    public float GetPropertyValue(Attributes attribute)
    {
        DKitProperty foundProperty = Found(attribute);
        return foundProperty.value;
    }
    public string GetPropertyAbbreviation(Attributes attribute)
    {
        DKitProperty foundProperty = Found(attribute);
        return foundProperty.abbreviation;
    }

    public string GetPropertyDescription(Attributes attribute)
    {
        DKitProperty foundProperty = Found(attribute);
        return foundProperty.abbreviation + " " + foundProperty.value;
    }
    private DKitProperty Found(Attributes attribute)
    {
        DKitProperty foundProperty = Properties.Find(property => property.attribute == attribute);
        if (foundProperty == null)
        {
            throw new ArgumentException($"Property {attribute} not found");
        }
        return foundProperty;
    }
}
