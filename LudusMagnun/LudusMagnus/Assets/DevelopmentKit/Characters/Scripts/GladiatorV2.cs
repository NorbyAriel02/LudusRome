using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GladiatorV2 
{
    public GladiatorObjectV2 data;
    public GladiatorV2(GladiatorObjectV2 data)
    {
        this.data = data;
    }
    public void WhenEquippingWeapons(Weapon weapon)
    {
        data.EquipedWeapon(weapon);
    }
    public void WhenUnequippingWeapons()
    {
        data.EquipedWeapon();
    }
    public void LevelUp()
    {
        data.SetHealth();
    }
}
