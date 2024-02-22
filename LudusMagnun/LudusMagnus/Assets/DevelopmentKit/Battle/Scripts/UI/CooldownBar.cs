using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{
    public Image imgCooldownBar;
    public GladiatorV2 gladiator = null;    
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
                timer = gladiator.data.attributes.GetPropertyValue(Attributes.CooldownAttack);

            UIHelper.SetfillAmount(ref imgCooldownBar, timer, gladiator.data.attributes.GetPropertyValue(Attributes.CooldownAttack));            
            yield return null;            
        }
        Debug.Log("End corrutine");
    }
}
