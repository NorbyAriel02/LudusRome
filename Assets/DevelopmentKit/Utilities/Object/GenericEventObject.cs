using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public abstract class GenericEventObject<T> : ScriptableObject
{
    protected List<GenericEventSubscriber<T>> events = new List<GenericEventSubscriber<T>>();
    public void AddSuscriber(GenericEventSubscriber<T> subscriber)
    {
        if (!events.Contains(subscriber))
            events.Add(subscriber);
    }
    public void RemoveSuscriber(GenericEventSubscriber<T> subscriber)
    {
        if (events.Contains(subscriber))
            events.Remove(subscriber);
    }
    public void CallEventes(T value)
    {
        foreach (GenericEventSubscriber<T> _event in events)
        {
            _event.subscribedMethod?.Invoke(value);
        }
    }
}
