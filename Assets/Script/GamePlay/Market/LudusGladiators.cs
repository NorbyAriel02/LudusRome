using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using UnityEngine;

public class LudusGladiators : MonoBehaviour
{
    public string savePath;
    List<GladiatorModel> lud;
    void Start()
    {
        lud = new List<GladiatorModel>();
    }
    private void OnDestroy()
    {
        List<GameObject> children = ChildrenController.GetListChildren(gameObject);
        foreach (GameObject child in children)
        {
            child.gameObject.SetActive(true);
            GladiatorObject gladiatorObject = child.GetComponent<StartGladiator>().gladiator.data;
            if (gladiatorObject != null)
            {
                GladiatorModel gladiatorModel = new GladiatorModel(gladiatorObject);
                lud.Add(gladiatorModel);
            }
        }
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
        formatter.Serialize(stream, lud);
        stream.Close();
    }

}
