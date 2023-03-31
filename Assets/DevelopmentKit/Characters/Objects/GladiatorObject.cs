using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character System/Character/New Gladiator")]
public class GladiatorObject : Character2DObject
{    
    public Stats attributes;
    public float baseHealthPoints = 50;
    public int level = 1;
    [NonSerialized] public float damagePoints;
    [NonSerialized] public float armorPoints;    
    [NonSerialized] public float maxHealthPoints;
    [NonSerialized] public float healthPoints;
    public void WhenEquippingWeapons(Weapon weapon)
    {
        damagePoints = weapon.damage + ((weapon.damage*0.3f)/attributes.force);
    }
    public void WhenUnequippingWeapons()
    {
        damagePoints = attributes.force;
    }
    public void LevelUp()
    {
        maxHealthPoints = baseHealthPoints + attributes.constitution + level;
        healthPoints = maxHealthPoints;
    }
}
