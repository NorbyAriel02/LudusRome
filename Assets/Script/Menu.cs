using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public EnumScene scenePlay;
    public EnumScene sceneOption;
    public EnumScene sceneCredits;
    public Button btnPlay;
    public Button btnCredits;
    public Button btnOptions;
    public Button btnExit;
    void Start()
    {
        btnOptions.onClick.AddListener(Options);
        btnPlay.onClick.AddListener(Play);
        btnCredits.onClick.AddListener(Credits);
        btnExit.onClick.AddListener(Exit);
    }
    private void Play()
    {
        SceneHelper.Load(scenePlay.ToString());
    }
    private void Options()
    {
        SceneHelper.Load(sceneOption.ToString());
    }
    private void Credits()
    {
        SceneHelper.Load(sceneCredits.ToString());
    }
    private void Exit()
    {
        Application.Quit();
    }
}
