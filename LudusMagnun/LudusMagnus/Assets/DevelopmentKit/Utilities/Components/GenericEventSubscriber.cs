using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class GenericEventSubscriber<T> : MonoBehaviour
{
    [SerializeField] private GenericEventObject<T> scriptableEvent;
    public UnityEvent<T> subscribedMethod;

    private void OnEnable()
    {
        scriptableEvent.AddSuscriber(this);
    }

    private void OnDisable()
    {
        scriptableEvent.RemoveSuscriber(this);
    }
}
