using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Seguir : EnemigoState
{    
    protected override void OnEnable()
    {
        if (motionModule == null)
            motionModule = GetComponent<MotionModule>();

        base.OnEnable();
    }
    public float GetVelocity()
    {
        return motionModule.navAgent.velocity.magnitude;
    }
    private void FixedUpdate()
    {
        if (!detectionModule.HadKnownTarget)
            Idle();
        else if (detectionModule.IsTargetInAttackRange)
            Attack();
        else
            GO();

        detectionModule.HandleTargetDetection(selftActor, selftColliders);
    }
    void GO()
    {
        motionModule.FallowTarget(detectionModule.KnownDetectedTarget.transform.position);
    }
    void Idle()
    {
        motionModule.Stop();
        stateMachine.NextState(nextState.GetIndexState("Idle"));
        OnExit?.Invoke();
    }
    void Attack()
    {
        motionModule.Stop();
        stateMachine.NextState(nextState.GetIndexState("Ataque"));
        OnExit?.Invoke();
    }
}
