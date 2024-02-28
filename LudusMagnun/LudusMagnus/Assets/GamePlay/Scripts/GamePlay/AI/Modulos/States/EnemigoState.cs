using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DetectionModule))]
[RequireComponent(typeof(MotionModule))]

public class EnemigoState : State
{
    protected DetectionModule detectionModule;
    protected MotionModule motionModule;
    protected Actor selftActor;
    protected Collider[] selftColliders;

    protected override void OnEnable()
    {
        if (selftActor == null)
            selftActor = GetComponent<Actor>();

        if (detectionModule == null)
            detectionModule = GetComponent<DetectionModule>();
        
        if (motionModule == null)
            motionModule = GetComponent<MotionModule>();
        
        if (detectionModule != null && motionModule != null)
            detectionModule.AttackRange = motionModule.GetStoppingDistance();

        if (selftColliders == null)
        {
            //El boxhit va en un hijo
            selftColliders = GetComponentsInChildren<Collider>();
        }
        base.OnEnable();
    }
}
