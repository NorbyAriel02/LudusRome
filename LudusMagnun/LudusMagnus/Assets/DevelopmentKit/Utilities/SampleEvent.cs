using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SampleEvent : MonoBehaviour
{
    public SampleEventObject sampleEvent;
    public string textTest;
    public KeyCode ActionKey;
    
    void Update()
    {
        if(Input.GetKeyDown(ActionKey))
        {
            sampleEvent.CallEventes(textTest);
        }
    }

    public void CallEventes(string value)
    {
        sampleEvent.CallEventes(value);
    }
}
