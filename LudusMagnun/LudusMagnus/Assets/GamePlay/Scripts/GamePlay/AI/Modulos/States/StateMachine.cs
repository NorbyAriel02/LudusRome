using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine : MonoBehaviour
{    
    public MonoBehaviour currentState;
    List<State> componets;
    private void Awake()
    {
        GetStates();
        NextState(0);
    }
    public void NextState(int index)
    {
        if(currentState != null) currentState.enabled = false;
        currentState = GetState(index);
        currentState.enabled = true;
    }
    void GetStates()
    {
        componets = GetComponents<State>().ToList();
        foreach(var state in componets)
            state.enabled = false;
    }
    MonoBehaviour GetState(int index)
    {
        return componets.Find(x => x.nextState.Index == index);
    }
}

/*El estado tendria enter, update y exit
 seria un MonoBehavior con un scriptable object de 
 parametro con los estados a los que va y el update
del stado tiene las condiciones para llamar el nuevo estado 
y la accion que tiene que hacer en ese estado
EL update puede ser una corrutina que se ejecutaria hasta que el objeto salga
con las corrutinas puedo retardar las acciones para que
el sujeto las ejecute segun sus atributos, por ejemplo 
reflejo, si la condision de cumple tiene 0.5f segundos de 
tiempo de reaccion para atacar*/