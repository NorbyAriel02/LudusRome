using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;
using static UnityEngine.Rendering.DebugUI;

[CreateAssetMenu(fileName = "New Character", menuName = "Character System/Character/New Gladiator V2")]
public class GladiatorObjectV2 : Character2DObject
{
    public DKitProperties attributes;
    public GladiatorV2 Create()
    {
        attributes.Create();
        SetHealth();
        SetDamage();
        SetCooldown();
        return new GladiatorV2(this);
    }
    public GladiatorV2 Create(GladiatorModelV2 gladiatorModel)
    {
        indexDB= gladiatorModel.id;
        name= gladiatorModel.name;        
        attributes = gladiatorModel.Stats;
        return new GladiatorV2(this);
    }

    public void SetHealth()
    {
        float bhp = attributes.GetPropertyValue(Attributes.BaseHealthPoints);
        float con = attributes.GetPropertyValue(Attributes.Constitution);
        float lvl = attributes.GetPropertyValue(Attributes.Level);
        float mhp = bhp + ((50 * con) / bhp) * lvl;
        attributes.SetPropertyValue(Attributes.MaxHealthPoints, mhp);
        attributes.SetPropertyValue(Attributes.HealthPoints, mhp);
    }
    private void SetDamage()
    {
        //float str = attributes.GetPropertyValue(Attributes.Strength);
        //float wd = attributes.GetPropertyValue(Attributes.WeapomDamage); 
        //float dp = str + wd;
        //attributes.SetPropertyValue(Attributes.DamagePoints, dp);
    }
    public void EquipedWeapon(Weapon weapon = null)
    {
        //float str = attributes.GetPropertyValue(Attributes.Strength);
        //float wd = (weapon != null) ? weapon.damage : 0;
        //float ww = (weapon != null) ? weapon.weight : 0;
        //float dp = str + wd;
        //attributes.SetPropertyValue(Attributes.DamagePoints, dp);
        //attributes.SetPropertyValue(Attributes.EquippedWeaponWeight, ww);
    }
    public void EquipedArmor(Armor armor = null)
    {        
        //float ad = (armor != null) ? armor.armor : 0;
        //attributes.SetPropertyValue(Attributes.ArmorPoints, ad);        
    }
    private void SetCooldown()
    {        
        //float dex = attributes.GetPropertyValue(Attributes.Dexterity);
        //float eww = attributes.GetPropertyValue(Attributes.EquippedWeaponWeight);
        //float cda = eww!=0 ? dex/eww:dex;
        //attributes.SetPropertyValue(Attributes.CooldownAttack, cda);        
    }


}
