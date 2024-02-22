using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VsController : MonoBehaviour
{
    public List<VS> paneles;
    public List<Image> Avatars;
    public GameObject prefab;
    public GameObject PanelGladiador;
    private GameObject GladiatorPlayer;
    private int indexAvatar;
    private void OnEnable()
    {
        GetVSGladiatorRandom();
        SelectBattleGladiator.OnSelectGladiator += GladiatorSelected;
    }
    private void OnDisable()
    {
        SelectBattleGladiator.OnSelectGladiator -= GladiatorSelected;
    }
    void GetVSGladiatorRandom()
    {
        foreach (var panel in paneles)
        {
            GladiatorV2 g = Helper.GetRandomGladiator(prefab, transform);
            panel.avatar.sprite = g.data.avatarUI;
            panel.txtName.text = g.data.name;
            int lvl = (int)g.data.attributes.GetPropertyValue(Attributes.Level);
            panel.txtLevel.text = lvl.ToString();
            panel.txtRevenue.text = Helper.GetRevenue(lvl);
        }
    }
    public void OpenListGladiator(int index)
    {
        indexAvatar = index;
        PanelGladiador.SetActive(true);
    }
    void GladiatorSelected(GameObject go)
    {
        StartGladiator startGladiator = go.GetComponent<StartGladiator>();
        if(startGladiator != null)
        {
            Avatars[indexAvatar].sprite = startGladiator.gladiator.data.avatarUI;
        }
        GladiatorPlayer = go;
        //go.transform.SetParent(transform);
    }
    public void GoBattler()
    {
        Debug.Log(paneles[indexAvatar].txtName.text + " VS " + GladiatorPlayer.GetComponent<StartGladiator>().gladiator.data.name);
    }
}
[Serializable]
public class VS
{    
    public Image avatar;    
    public Button btnSelect;
    public TMP_Text txtName;
    public TMP_Text txtLevel;
    public TMP_Text txtRevenue;
}