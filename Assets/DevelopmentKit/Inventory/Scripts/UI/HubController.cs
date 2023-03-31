using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubController : MonoBehaviour
{
    public GameObject PanelInventory;
    public GameObject PanelEquipment;
    public KeyCode OpenInventory;
    public KeyCode OpenEquipment;
    void Start()
    {        
        SetPanel(PanelInventory);
        SetPanel(PanelEquipment);
    }
    void SetPanel(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }
    void Update()
    {
        if(Input.GetKeyDown(OpenInventory))
        {
            SetPanel(PanelInventory);
        }
        if (Input.GetKeyDown(OpenEquipment))
        {
            SetPanel(PanelEquipment);
        }
    }
}
