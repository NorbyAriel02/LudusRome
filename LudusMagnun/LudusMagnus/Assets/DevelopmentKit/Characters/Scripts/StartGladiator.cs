using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGladiator : MonoBehaviour
{
    public GladiatorDataBaseObject db;
    public GladiatorV2 gladiator;
    public Transform view;
    void Awake()
    {
        StartRandomGladiator();
    }  
    public void UpdateCharacter(int index)
    {
        ChildrenController.RemoveAllChildren(view.gameObject);
        gladiator = db.GladiatorObjects[index].Create();        
        Instantiate(gladiator.data.Character, view);
    }
    public void UpdateCharacter(GladiatorModelV2 model)
    {
        ChildrenController.RemoveAllChildren(view.gameObject);
        gladiator = db.GladiatorObjects[model.id].Create(model);
        Instantiate(gladiator.data.Character, view);
    }
    void StartRandomGladiator()
    {
        int i = UnityEngine.Random.Range(0, db.GladiatorObjects.Length);
        gladiator = db.GladiatorObjects[i].Create();
        Instantiate(gladiator.data.Character, view);
    }
}
