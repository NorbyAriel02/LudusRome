using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CharismaBar : MonoBehaviour
{
    public float maxCharisma = 100;
    public Image imgCharismaBar;
    public GladiatorV2 gladiator = null;
    private int countAttack = 0;
    private void OnEnable()
    {
        BattleController.OnAttack += OnAttack;
    }
    private void Start()
    {
        gladiator = GetComponent<StartGladiator>().gladiator;
    }    
    public void OnAttack()
    {
        float charisma = gladiator.data.attributes.GetPropertyValue(Attributes.Charisma);
        countAttack++;
        float fx = (charisma * countAttack)/ maxCharisma;
        UIHelper.SetfillAmount(ref imgCharismaBar, fx);
    }
    
}
