using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.UI;

public static class UIHelper 
{
    /*Si currentValue es entre 0 y 1, maxValue es opcional*/
    public static void SetfillAmount(ref UnityEngine.UI.Image img, float currentValue, float maxValue = 1)
    {
        img.fillAmount = (currentValue / maxValue);        
    }

    public static void SetButtonEvent(ref Button btn, string nameEvent)
    {
        
    }
}
