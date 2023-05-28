using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArenaController : MonoBehaviour
{
    public List<Button> buttons;
    public Button btnLudus;
    public Button btnMarket;
    public Button btnBack;
    public TMP_Text txtDescripZona;
    public GameObject panelCombat;

    void Start()
    {
        int count = 0;
        foreach (var button in buttons)
        {
            int index = count;
            button.onClick.AddListener(delegate { LoadArena(index); });
            count++;
        }
        btnLudus.onClick.AddListener(delegate { LoadScene(EnumScene.Ludus); });
        btnMarket.onClick.AddListener(delegate { LoadScene(EnumScene.Mercado); });
        btnBack.onClick.AddListener(delegate { LoadScene(EnumScene.Menu); });
    }
    public void LoadArena(int index)
    {
        panelCombat.SetActive(true);
    }
    public void LoadScene(EnumScene enumScene)
    {
        SceneHelper.Load(enumScene.ToString());
    }

}
