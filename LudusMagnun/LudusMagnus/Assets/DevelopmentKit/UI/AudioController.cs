using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public UIOptionObject ui;
    public float sliderMasterValue;
    public Image iconSound;
    public Sprite[] images;
    public Slider slider;

    private void Start()
    {
        ui.Load();
        ChangerSlider(ui.options.masterSonidosValue);
    }

    public void ChangerSlider(float value)
    {
        slider.value = value;
        AudioListener.volume = value;
        ChangeIconSound(value);
        ui.options.masterSonidosValue = value; 
        ui.Save();
    }
    
    public void ChangeIconSound(float value)
    {
        if (value < 0.5f && value > 0)
        {
            iconSound.sprite = images[1];
        }
        else if (value > 0.5f)
        {
            iconSound.sprite = images[2];
        }
        else
        {
            iconSound.sprite = images[0];
        }
    }
}
