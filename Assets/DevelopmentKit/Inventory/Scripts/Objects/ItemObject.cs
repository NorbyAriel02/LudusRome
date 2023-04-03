﻿using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory System/Items/New Item")]
public class ItemObject : ScriptableObject
{
    public Sprite uiDisplay;
    public GameObject characterDisplay;        
    [TextArea(15, 20)] public string description;
    public Item data = new Item();
    public List<string> boneNames = new List<string>();    
    public Item CreateItem()
    {        
        return new Item(this); 
    }

    private void OnValidate()
    {
        boneNames.Clear();
        if (characterDisplay == null) 
            return;
        if(!characterDisplay.GetComponent<SkinnedMeshRenderer>())
            return;

        var renderer = characterDisplay.GetComponent<SkinnedMeshRenderer>();
        var bones = renderer.bones;

        foreach (var t in bones)
        {
            boneNames.Add(t.name);
        }
    }
}
