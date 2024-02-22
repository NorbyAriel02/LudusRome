using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a name class can not start with a number, example: 2DCharacterObject
[CreateAssetMenu(fileName = "New Character", menuName = "Character System/Character/New 2D Character")]
public class Character2DObject : CharacterObject
{
    public Sprite avatarUI;
    public GameObject Character;
}
