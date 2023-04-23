using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public enum EnumScene : int
{
    None,
    [EnumMember(Value = "Menu")]
    Menu,
    [EnumMember(Value = "Opciones")]
    Opciones,
    [EnumMember(Value = "level")]
    Level,
    [EnumMember(Value = "Creditos")]
    Creditos,
    [EnumMember(Value = "Desa")]
    Desa
}

