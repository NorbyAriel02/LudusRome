using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PanelStatsController : MonoBehaviour
{
    public TMP_Text txtLevel;
    public TMP_Text txtStrength;
    public TMP_Text txtDexterity;
    public TMP_Text txtConstitution;
    public TMP_Text txtInteligence;
    public TMP_Text txtWisdom;
    public TMP_Text txtCharisma;
    public TMP_Text txtValue;

    private void OnEnable()
    {
        MarketController.OnChange += SetTextStat;
        LudusController.OnChange += SetTextStat;
    }
    private void OnDisable()
    {
        MarketController.OnChange -= SetTextStat;
        LudusController.OnChange -= SetTextStat;
    }
    private void Clear()
    {
        txtStrength.text = "0";
        txtConstitution.text = "0";
        txtCharisma.text = "0";
        txtDexterity.text = "0";
        txtInteligence.text = "0";
        txtLevel.text = "0";
        txtValue.text = "0";
    }
    private void SetTextStat(GladiatorV2 gladiator)
    {
        if (gladiator == null)
        {
            Clear();
            return;
        }
        txtStrength.text = gladiator.data.attributes.GetPropertyValue(Attributes.Strength).ToString();
        txtConstitution.text = gladiator.data.attributes.GetPropertyValue(Attributes.Constitution).ToString();
        txtCharisma.text = gladiator.data.attributes.GetPropertyValue(Attributes.Charisma).ToString();
        txtDexterity.text = gladiator.data.attributes.GetPropertyValue(Attributes.Dexterity).ToString();
        txtInteligence.text = gladiator.data.attributes.GetPropertyValue(Attributes.Intelligence).ToString();
        txtLevel.text = gladiator.data.attributes.GetPropertyValue(Attributes.Level).ToString();
        txtValue.text = gladiator.data.attributes.GetPropertyValue(Attributes.Value).ToString();
    }
}
