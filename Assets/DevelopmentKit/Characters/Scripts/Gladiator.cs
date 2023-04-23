using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Gladiator 
{
    public GladiatorObject data;
    public Gladiator(GladiatorObject data)
    {
        this.data = data;
    }
    public void WhenEquippingWeapons(Weapon weapon)
    {
        data.damagePoints = weapon.damage + ((weapon.damage * 0.3f) / data.attributes.Strength);
    }
    public void WhenUnequippingWeapons()
    {
        data.damagePoints = data.attributes.Strength;
    }
    public void LevelUp()
    {
        data.maxHealthPoints = data.baseHealthPoints + data.attributes.constitution + data.level;
        data.healthPoints = data.maxHealthPoints;
    }
}
