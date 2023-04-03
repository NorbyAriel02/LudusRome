using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGladiator : MonoBehaviour
{
    public GladiatorObject gladiatorObject;
    public Gladiator gladiator;
    void Awake()
    {
        gladiator = gladiatorObject.Create();
    }

    
    void Update()
    {
        
    }
}
