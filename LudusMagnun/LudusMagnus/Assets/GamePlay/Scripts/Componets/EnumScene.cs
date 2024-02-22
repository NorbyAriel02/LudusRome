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
    [EnumMember(Value = "Ludus")]
    Ludus,
    [EnumMember(Value = "Creditos")]
    Creditos,
    [EnumMember(Value = "Mercado")]
    Mercado,
    [EnumMember(Value = "Arenas")]
    Arenas,
    [EnumMember(Value = "Arena")]
    Arena,
    [EnumMember(Value = "Desa")]
    Desa
}

