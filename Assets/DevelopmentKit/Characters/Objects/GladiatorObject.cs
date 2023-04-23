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
    public int value = 1;
    [NonSerialized] public float damagePoints;
    [NonSerialized] public float armorPoints;    
    [NonSerialized] public float maxHealthPoints;
    [NonSerialized] public float healthPoints;
    [NonSerialized] public float cooldownAttack;
    public Gladiator Create()
    {
        SetHealth();
        SetDamage();
        SetCooldown();
        return new Gladiator(this);
    }
    private void SetHealth()
    {
        maxHealthPoints = baseHealthPoints + ((50*attributes.constitution)/baseHealthPoints)*level;
        healthPoints = maxHealthPoints;
    }
    private void SetDamage()
    {
        damagePoints = level * (attributes.Strength/50) + attributes.Strength;
    }

    private void SetCooldown()
    {
        cooldownAttack = 10 - attributes.dexterity;
    }
}
