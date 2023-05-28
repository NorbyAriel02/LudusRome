using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image imgHealth;
    public GladiatorV2 gladiator = null;
    private void OnEnable()
    {
        BattleController.OnAttack += UpdateHealthBar;
    }
    private void Start()
    {
        gladiator = GetComponent<StartGladiator>().gladiator;
    }
    public void UpdateHealthBar()
    {
        //obtengo la vida actual
        //obtengo la vida maxima
        float health = gladiator.data.attributes.GetPropertyValue(Attributes.HealthPoints);
        float maxHealth = gladiator.data.attributes.GetPropertyValue(Attributes.MaxHealthPoints);
        UIHelper.SetfillAmount(ref imgHealth, health, maxHealth);
    }
    void Update()
    {
        
    }
}
