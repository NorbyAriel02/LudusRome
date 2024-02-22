using System.Collections;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ZonaInformation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int level = 1;
    public string country;
    [TextAreaAttribute]
    public string Description;
    public TMP_Text txtZonaInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        txtZonaInfo.text = string.Format(Description, level, country);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
    void OnMouseOver()
    {
        txtZonaInfo.text = string.Format(Description, level, country);
    }
}
