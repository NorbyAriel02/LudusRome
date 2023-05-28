using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;

public class LoadGladiatorList : MonoBehaviour
{
    public string savePath;
    public GameObject prefab;
    public List<GladiatorModelV2> listGladiators;
    void Awake()
    {
        Load();
    }

    public void Load()
    {
        listGladiators = ObjectHelper.GetObject<List<GladiatorModelV2>>(savePath);
        foreach (var model in listGladiators)
        {
            GameObject goGladiator = Instantiate(prefab, transform);
            goGladiator.GetComponent<StartGladiator>().UpdateCharacter(model);
            goGladiator.SetActive(false);
        }
    }
}
