using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Idle : EnemigoState
{
    /*desde este estado puede pasar a el estado avanzar o atacar
     avanza si detecta un objetivo que no este dentro de su rango de ataque
    o ataca si hay un enemigo en el rango*/
    public float DelayPatrulla = 3;
    private float timer;
    protected override void OnEnable()
    {
        /* Aca activamos la accion del estado, 
         * lo que va hacer mientras dure el 
         * estado tambien podemos activar alguna corrutina que verique */        
        timer = DelayPatrulla;        
        base.OnEnable();
    }
    
    void Update()
    {
        //detectamos siempre para actualizar el target siempre (null, know, inAttackRange)
        detectionModule.HandleTargetDetection(selftActor, selftColliders);

        if (detectionModule.IsTargetInAttackRange)
            Attack();
        else if (detectionModule.HadKnownTarget)
            Seguir();

        timer -= Time.deltaTime;
        if(timer < 0)
            Patrulla();
    }
    void Attack()
    {
        stateMachine.NextState(nextState.GetIndexState("Ataque"));
        OnExit?.Invoke();
    }
    void Seguir()
    {
        stateMachine.NextState(nextState.GetIndexState("Seguir"));
        OnExit?.Invoke();
    }
    void Patrulla()
    {
        stateMachine.NextState(nextState.GetIndexState("Patrullar"));
        OnExit?.Invoke();
    }
}
