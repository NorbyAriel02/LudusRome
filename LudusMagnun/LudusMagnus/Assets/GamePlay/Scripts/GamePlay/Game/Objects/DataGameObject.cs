using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New DataGame", menuName = "Data Game/New DataGame", order = 1)]
public class DataGameObject : ScriptableObject
{
    public Guid idGame;
    public new string name;
    public DateTime date;
    public string path;
    public ContainerObject inventory;
    public ContainerListObject equipments;
    public List<Partida> partidaList;
}
