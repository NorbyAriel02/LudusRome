using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class BattleController : MonoBehaviour
{
    public delegate void Attack();
    public delegate void Battle();
    public static Attack OnAttack;
    public static Battle MiteOrIogula;
    public static Battle EndBattle;
    public float healthEndBattle = 5;
    public GameObject gladiatorGO1;
    public GameObject gladiatorGO2;
    private GladiatorV2 gladiator1;
    private GladiatorV2 gladiator2;
    private BattleManager battleManager;
    void Start()
    {
        battleManager = new BattleManager();
        gladiator1 = gladiatorGO1.GetComponent<StartGladiator>().gladiator;
        gladiator2 = gladiatorGO2.GetComponent<StartGladiator>().gladiator;
        PrintStat(gladiator1);
        PrintStat(gladiator2);
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(BattleCorrutine(gladiator1.data, gladiator2.data));
            StartCoroutine(BattleCorrutine(gladiator2.data, gladiator1.data));
        }
    }
    private void PrintStat(GladiatorV2 gladiator)
    {
        Debug.Log(gladiator.data.name);
        foreach (var s in gladiator.data.attributes.Properties)
        {
            Debug.Log(s.attribute + " " + s.value);
        }
    }
    IEnumerator BattleCorrutine(GladiatorObjectV2 attacker, GladiatorObjectV2 defender)
    {        
        while (defender.attributes.GetPropertyValue(Attributes.HealthPoints) >= healthEndBattle)
        {
            yield return new WaitForSeconds(attacker.attributes.GetPropertyValue(Attributes.CooldownAttack));
            defender.attributes.SetPropertyValue(Attributes.HealthPoints, (defender.attributes.GetPropertyValue(Attributes.HealthPoints) - battleManager.AttackTest(attacker, defender)));            
            OnAttack?.Invoke();
        } 
        StopAllCoroutines();
        if(defender.attributes.GetPropertyValue(Attributes.HealthPoints) > 0)
            MiteOrIogula?.Invoke();
        else
            EndBattle?.Invoke();
    }

}
