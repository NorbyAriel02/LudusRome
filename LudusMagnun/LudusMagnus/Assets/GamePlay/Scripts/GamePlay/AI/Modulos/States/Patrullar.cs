using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(WaypointDetectionModule))]
public class Patrullar : EnemigoState
{    
    private WaypointDetectionModule waypointDetectionModule;
    private int waypointIndex = 0;
    protected override void OnEnable()
    {   
        if (waypointDetectionModule == null)
            waypointDetectionModule = GetComponent<WaypointDetectionModule>();

        waypointDetectionModule.HandleWaypointDetection();        
        base.OnEnable();
    }
    public float GetVelocity()
    {
        return motionModule.navAgent.velocity.magnitude;
    }
    private void FixedUpdate()
    {
        if (detectionModule.HadKnownTarget)
            SeguirObjetivo();
        else
            GO();

        detectionModule.HandleTargetDetection(selftActor, selftColliders);
    }
    void GO()
    {        
        if (motionModule.IsArrived())
            waypointIndex++;

        waypointIndex = waypointIndex >= waypointDetectionModule.KnownDetectedWayPoints.Count ? 0 : waypointIndex;        
        motionModule.FallowTarget(waypointDetectionModule.KnownDetectedWayPoints[waypointIndex].position);
    }
    void SeguirObjetivo()
    {        
        stateMachine.NextState(nextState.GetIndexState("Seguir"));
        OnExit?.Invoke();
    }    
}
