using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PanelSell : MonoBehaviour
{
    public delegate void Close();
    public static Close OnClose;
    public Button btnOk; 
    void Start()
    {
        btnOk.onClick.AddListener(Ok);
    }
    void Ok()
    {
        gameObject.SetActive(false);
        OnClose?.Invoke();
    }
}
