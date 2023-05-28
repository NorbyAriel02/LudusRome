using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharismaController : MonoBehaviour
{
    private BattleController battleController;
    private GladiatorV2 gladiator;
    void Start()
    {        
        BattleController.OnAttack += UpdateCharisma;
    }

    private void UpdateCharisma()
    {
        
    }
}
