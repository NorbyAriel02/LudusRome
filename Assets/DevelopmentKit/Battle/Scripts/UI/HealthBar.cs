using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image imgHealth;
    public Gladiator gladiator = null;
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
        float health = gladiator.data.healthPoints;
        float maxHealth = gladiator.data.maxHealthPoints;
        UIHelper.SetHealthBar(ref imgHealth, health, maxHealth);
    }
    void Update()
    {
        
    }
}
