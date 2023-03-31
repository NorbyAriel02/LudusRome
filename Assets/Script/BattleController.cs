using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public GladiatorObject gladiator1;
    public GladiatorObject gladiator2;
    
    private BattleManager battleManager;
    void Start()
    {
        battleManager = new BattleManager();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(BattleCorrutine(gladiator1, gladiator2));
        }
    }

    IEnumerator BattleCorrutine(GladiatorObject attacker, GladiatorObject defender)
    {        
        defender.healthPoints = (defender.healthPoints - battleManager.AttackTest(attacker, defender));
        Debug.Log(defender.healthPoints);
        yield return new WaitForSeconds(1);
    }
}
