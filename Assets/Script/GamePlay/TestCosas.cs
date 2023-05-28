using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCosas : MonoBehaviour
{
    public GladiatorObjectV2 gladiator;
    void Start()
    {
        GladiatorV2 gladiatorV2 = gladiator.Create();        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
