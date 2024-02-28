using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : EnemigoState
{
    public float offsetDelay = 0f;
    //AnimatorModule animatorModule;
    //float delay = 0f;
    protected override void OnEnable()
    {
        //if(animatorModule == null) 
        //    animatorModule = GetComponent<AnimatorModule>();

        //if (delay <= 0)
        //{
        //    delay = animatorModule.GetAnimationDutarion("Attack01");
        //    print("delay " + delay);
        //}
        base.OnEnable();        
    }

    //IEnumerator Attack()
    //{        
    //    yield return new WaitForSeconds(delay + offsetDelay);
    //    GameObject objetive = detectionModule.KnownDetectedTarget;
    //    Destroy(objetive);
    //    detectionModule.ResetTarget();
    //    stateMachine.NextState(nextState.GetIndexState("Idle"));
    //}
    public void OnHit()
    {
        GameObject objetive = detectionModule.KnownDetectedTarget;
        Destroy(objetive);
        detectionModule.ResetTarget();
        stateMachine.NextState(nextState.GetIndexState("Idle"));        
    }
}
