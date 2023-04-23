using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGladiator : MonoBehaviour
{
    public GladiatorDataBaseObject db;
    public Gladiator gladiator;
    public Transform view;
    void Awake()
    {
        int i = Random.Range(0, db.GladiatorObjects.Length);
        gladiator = db.GladiatorObjects[i].Create();
        GameObject character = Instantiate(gladiator.data.Character, view);
    }    
}
