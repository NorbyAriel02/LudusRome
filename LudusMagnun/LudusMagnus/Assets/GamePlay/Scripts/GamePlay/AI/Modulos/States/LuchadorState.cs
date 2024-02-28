using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DetectionModule))]
public class LuchadorState : State
{
    protected DetectionModule detectionModule;
    protected Actor selftActor;
    protected Collider[] selftColliders;
    
    protected override void OnEnable()
    {
        if (selftActor == null)
            selftActor = GetComponent<Actor>();

        if (detectionModule == null)
            detectionModule = GetComponent<DetectionModule>();

        if (selftColliders == null)
        {
            //El boxhit va en un hijo
            selftColliders = GetComponentsInChildren<Collider>();            
        }
            

        base.OnEnable();
    }
}
