using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static BattleController;

public class CooldownBar : MonoBehaviour
{
    public Image imgCooldownBar;
    public Gladiator gladiator = null;    
    private float timer;
    private bool isCombat = false;
    private void OnEnable()
    {
        BattleController.EndBattle += EndCombat;
        BattleController.MiteOrIogula += EndCombat;
    }
    private void Start()
    {
        gladiator = GetComponent<StartGladiator>().gladiator;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            isCombat = true;
            StartCoroutine(CooldownCorrutine());
        }
    }
    public void EndCombat()
    {
        isCombat = false;
        StopCoroutine(CooldownCorrutine());
    }
    IEnumerator CooldownCorrutine()
    {
        while (isCombat)
        {
            timer -= Time.deltaTime;
            
            if (timer < 0)
                timer = gladiator.data.cooldownAttack;

            UIHelper.SetHealthBar(ref imgCooldownBar, timer, gladiator.data.cooldownAttack);            
            yield return null;            
        }
        Debug.Log("End corrutine");
    }
}
