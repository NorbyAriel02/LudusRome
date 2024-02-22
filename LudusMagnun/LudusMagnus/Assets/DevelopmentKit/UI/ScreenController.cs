using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScreenController : MonoBehaviour
{
    public TMP_Dropdown dropdownQuallity;
    public TMP_Dropdown dropdownResolution;
    public Toggle toggle;
    Resolution[] resolutions;
    public UIOptionObject ui;
    void Start()
    {
        ui.Load();
        QualitySettings.SetQualityLevel(ui.options.QualitySetting);
        dropdownQuallity.value = ui.options.QualitySetting;
        FullScreen(ui.options.fullScreen);
        LoadResolutios();
    }
    void LoadResolutios()
    {
        int count = 0;
        resolutions = Screen.resolutions;
        dropdownResolution.ClearOptions();
        List<string> list = new List<string>();
        foreach (var resolution in resolutions)
        {
            string option = resolution.width + "x" + resolution.height;
            list.Add(option);
            if(ui.options.resolution == -1 && Screen.currentResolution.width == resolution.width 
                && Screen.currentResolution.height == resolution.height)
            {
                ui.options.resolution = count;
            }
            count++;
        }
        dropdownResolution.AddOptions(list);
        dropdownResolution.value = ui.options.resolution;
        dropdownResolution.RefreshShownValue();
    }
    public void FullScreen(bool value)
    {
        toggle.isOn = value;
        ui.options.fullScreen = value;
        Screen.fullScreen = ui.options.fullScreen;                 
    }
    public void ChangeQuallity()
    {
        QualitySettings.SetQualityLevel(dropdownQuallity.value);
        ui.options.QualitySetting = dropdownQuallity.value;        
    }
    public void ChangeResolution(int value)
    {
        Resolution r = resolutions[value];
        Screen.SetResolution(r.width,r.height, Screen.fullScreen);
        ui.options.resolution = value;
    }
}
