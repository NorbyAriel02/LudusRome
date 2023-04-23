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
    }
    private void OnDisable()
    {
        MarketController.OnChange -= SetTextStat;
    }
    private void SetTextStat(Gladiator gladiator)
    {
        txtStrength.text = gladiator.data.attributes.Strength.ToString();
        txtConstitution.text = gladiator.data.attributes.constitution.ToString();
        txtCharisma.text = gladiator.data.attributes.charisma.ToString();
        txtDexterity.text = gladiator.data.attributes.dexterity.ToString();
        txtInteligence.text = gladiator.data.attributes.intelligence.ToString();
        txtLevel.text = gladiator.data.level.ToString();
        txtValue.text = gladiator.data.value.ToString();
    }
}
