using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Formulas 
{
    public static float GetValueAttributeForLevel(int lvl, float baseValue)
    {
        /*Aca defino una formula que me devuelva 
         * el valor que busco, en este caso defino 
         * un valor que se incrementa linealmente con el nivel*/
        return lvl * baseValue;
    }
}
