using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;
public class LudusGladiators : MonoBehaviour
{
    public string savePath;
    public GameObject prefab;
    public List<GladiatorModelV2> listGladiators;
    void Start()
    {
        listGladiators = new List<GladiatorModelV2>();
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
    private void OnDestroy()
    {
        listGladiators.Clear();
        List<GameObject> children = ChildrenController.GetListChildren(gameObject);
        foreach (GameObject child in children)
        {
            if(child.GetComponent<StartGladiator>() == null)
                continue;

            child.gameObject.SetActive(true);
            GladiatorObjectV2 gladiatorObject = child.GetComponent<StartGladiator>().gladiator.data;
            if (gladiatorObject != null)
            {
                GladiatorModelV2 gladiatorModel = new GladiatorModelV2(gladiatorObject);
                listGladiators.Add(gladiatorModel);
            }
        }
        ObjectHelper.SaveObject<List<GladiatorModelV2>>(savePath, listGladiators);
    }

}
