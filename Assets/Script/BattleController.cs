using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEditor.Experimental.GraphView;
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
    private Gladiator gladiator1;
    private Gladiator gladiator2;
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
    private void PrintStat(Gladiator gladiator)
    {
        Debug.Log(gladiator.data.name);
        Debug.Log(" healthPoints->" + gladiator.data.healthPoints);
        Debug.Log(" cooldownAttack->" + gladiator.data.cooldownAttack);
        Debug.Log(" damagePoints->" + gladiator.data.damagePoints);
        Debug.Log(" armorPoints->" + gladiator.data.armorPoints);
    }
    IEnumerator BattleCorrutine(GladiatorObject attacker, GladiatorObject defender)
    {   
        while(defender.healthPoints >= healthEndBattle)
        {
            yield return new WaitForSeconds(attacker.cooldownAttack);
            defender.healthPoints = (defender.healthPoints - battleManager.AttackTest(attacker, defender));            
            OnAttack?.Invoke();
        } 
        StopAllCoroutines();
        if(defender.healthPoints > 0)
            MiteOrIogula?.Invoke();
        else
            EndBattle?.Invoke();
    }
}
