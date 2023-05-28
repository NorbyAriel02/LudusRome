using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;

public class SaveGladiatorList : MonoBehaviour
{
    public string savePath;
    public List<GladiatorModelV2> listGladiators;
    private void Save()
    {
        listGladiators.Clear();
        List<GameObject> children = ChildrenController.GetListChildren(gameObject);
        foreach (GameObject child in children)
        {
            if (child.GetComponent<StartGladiator>() == null)
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
    private void OnDestroy()
    {
        Save();
    }
}
