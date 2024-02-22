using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Character", menuName = "Character System/Character/New Character")]
public class CharacterObject : ScriptableObject
{
    private static int _IndexCounter = 0;
    public Guid id;
    public int indexDB;
    public new string name;
    private void OnEnable()
    {
        id = Guid.NewGuid();
        indexDB = _IndexCounter;
        _IndexCounter++;
        name = StringHelper.GetName();
    }
}
