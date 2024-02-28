using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New State", menuName = "State System/New State", order = 1)]
public class StateObject : GenericObject
{
    public List<StateObject> stateToTransition;
    public string animationTrigger;

    public int GetIndexState(string stateName)
    {
        return stateToTransition.Find( x => x.name == stateName).Index;
    }
}
