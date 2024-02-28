using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(StateMachine))]
public class State : MonoBehaviour
{
    public Renderer MarcaDeEstado;
    public Color color;
    public StateObject nextState;
    protected StateMachine stateMachine;
    public UnityEvent OnEnter;
    public UnityEvent OnUpdate;
    public UnityEvent OnExit;
    protected virtual void OnEnable()
    {        
        print(nextState.name + " " + Time.time.ToString("0.0"));
        if (stateMachine == null)
            stateMachine = GetComponent<StateMachine>();

        if (MarcaDeEstado == null)
        {
            GameObject go = ChildrenController.GetChildWithTag(gameObject, "MarcaDeEstado");
            MarcaDeEstado = go.GetComponent<Renderer>();
        }            
        
        if (MarcaDeEstado != null)
            MarcaDeEstado.material.color = color;

        OnEnter?.Invoke();
    }
    protected virtual void UpdateState()
    {
        //OnUpdate?.Invoke();
    }
    protected virtual void OnDisable()
    {
        //OnExit?.Invoke();
    }
}
