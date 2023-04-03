using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager 
{
    /*aca el ataque recibe el daño y la armadura y calcula el daño 
     * en puntos de vida que se le hace al que recibe el ataque, 
     * si tiene mucha defensa puede que no reciba daño*/
    public float AttackTest(GladiatorObject attacker, GladiatorObject defender)
    {        
        return FormuleAttack(attacker.damagePoints, defender.armorPoints);
    }

    public virtual float FormuleAttack(float attack, float armor)
    {
        return (attack * 3f - armor);
    }
}
