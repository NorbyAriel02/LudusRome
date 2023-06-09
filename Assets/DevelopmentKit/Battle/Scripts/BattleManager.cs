using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager 
{
    /*aca el ataque recibe el da�o y la armadura y calcula el da�o 
     * en puntos de vida que se le hace al que recibe el ataque, 
     * si tiene mucha defensa puede que no reciba da�o*/
    public float AttackTest(GladiatorObjectV2 attacker, GladiatorObjectV2 defender)
    {        
        return FormuleAttack(attacker.attributes.GetPropertyValue(Attributes.DamagePoints), defender.attributes.GetPropertyValue(Attributes.ArmorPoints));
    }

    public virtual float FormuleAttack(float attack, float armor)
    {
        return (attack * 3f - armor);
    }
}
