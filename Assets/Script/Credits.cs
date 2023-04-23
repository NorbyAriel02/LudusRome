using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public EnumScene sceneMenu;    
    public Button btnBack;
    void Start()
    {
        btnBack.onClick.AddListener(Back);
    }

    private void Back()
    {
        SceneHelper.Load(sceneMenu.ToString());
    }
}
