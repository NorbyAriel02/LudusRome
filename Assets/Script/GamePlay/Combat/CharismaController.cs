using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharismaController : MonoBehaviour
{
    private BattleController battleController;
    private Gladiator gladiator;
    void Start()
    {        
        BattleController.OnAttack += UpdateCharisma;
    }

    private void UpdateCharisma()
    {
        
    }
}
