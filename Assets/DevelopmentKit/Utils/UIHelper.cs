using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public static class UIHelper 
{
    public static void SetHealthBar(ref UnityEngine.UI.Image bar, float currentHealth, float maxHealth)
    {
        bar.fillAmount = (currentHealth / maxHealth);        
    }
}
