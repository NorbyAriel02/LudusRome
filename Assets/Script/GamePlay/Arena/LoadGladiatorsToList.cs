using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadGladiatorsToList : MonoBehaviour
{
    public GameObject prefabItem;
    public Transform content;
    public GameObject gladiators;
    
    private void OnEnable()
    {
        List<GameObject> listGladiators = ChildrenController.GetListChildren(gladiators);        
        ChildrenController.RemoveAllChildren(content.gameObject);
        if (listGladiators != null)
        {
            foreach (var gladiator in listGladiators)
            {
                GladiatorObjectV2 data = gladiator.GetComponent<StartGladiator>().gladiator.data;
                GameObject go = Instantiate(prefabItem, content);
                //item.transform.SetParent(go.transform);
                go.GetComponent<SelectBattleGladiator>().Gladiator = gladiator;
                GameObject[] children = ChildrenController.GetChildren(go);
                SetText(children, data);
            }
        }
    }

    void SetText(GameObject[] children, GladiatorObjectV2 gm)
    {
        foreach (var txt in children)
        {
            if (txt.name.Equals("AvatarGladiador"))
            {
                txt.GetComponent<Image>().sprite = gm.avatarUI;
            }
            if (txt.name.Equals("bgDatos"))
            {
                GameObject[] children2 = ChildrenController.GetChildren(txt);
                SetText(children2,gm);
            }
            if(txt.name.Equals("txtName"))
            {
                txt.GetComponent<TMP_Text>().text = gm.name;
            }
            if (txt.name.Equals("txtLevel"))
            {
                txt.GetComponent<TMP_Text>().text = gm.attributes.GetPropertyValue(Attributes.Level).ToString();
            }
            if (txt.name.Equals("txtStats"))
            {                
                txt.GetComponent<TMP_Text>().text = gm.attributes.GetPropertyDescription(Attributes.DamagePoints) + " " + gm.attributes.GetPropertyDescription(Attributes.ArmorPoints) + " " + gm.attributes.GetPropertyDescription(Attributes.CooldownAttack);
            }
        }
    }

}
