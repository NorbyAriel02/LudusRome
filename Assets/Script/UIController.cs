using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject panelEndBattle;
    public GameObject panelMiteOrIogula;
    private void OnEnable()
    {
        BattleController.MiteOrIogula += MiteOrIogula;
        BattleController.EndBattle += EndBattle;
    }
    private void OnDisable()
    {
        BattleController.MiteOrIogula -= MiteOrIogula;
        BattleController.EndBattle -= EndBattle;
    }
    void Start()
    {        
        panelEndBattle.SetActive(false);
        panelMiteOrIogula.SetActive(false);
    }
    void EndBattle()
    {
        panelEndBattle.SetActive(true);
    }
    void MiteOrIogula()
    {
        panelMiteOrIogula.SetActive(true);
    }
}
