using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericObject : ScriptableObject
{
    public new string name;
    [TextArea(2, 5)]
    public string description;
    [SerializeField]private int index;
    public int Index { get { return index; } set { index = value; } }
}
