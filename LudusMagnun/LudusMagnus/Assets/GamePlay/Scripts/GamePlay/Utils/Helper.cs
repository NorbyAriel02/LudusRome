using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper 
{
    public static GladiatorV2 GetRandomGladiator(GameObject prefab, Transform father, int minLevel = 1)
    {
        GameObject go = GameObject.Instantiate(prefab, father);
        StartGladiator sg = go.GetComponent<StartGladiator>();
        sg.gladiator.data.name = StringHelper.GetName();
        return sg.gladiator;
    }

    public static string GetRevenue(int level)
    {
        int min = 300;
        int max = 1500;
        int revenue = Random.Range(min*level, max*level);

        return revenue + "/" + (revenue*20)/100;
    }
}
