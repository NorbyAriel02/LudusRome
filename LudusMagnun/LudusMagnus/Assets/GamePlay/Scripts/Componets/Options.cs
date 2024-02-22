using UnityEngine.UI;
using UnityEngine;

public class Options : MonoBehaviour
{
    public EnumScene sceneMenu;
    public Button btnAplicar;
    public Button btnCancelar;
    public UIOptionObject ui;
    void Start()
    {
        ui.Load();
        btnAplicar.onClick.AddListener(Aplicar);
        btnCancelar.onClick.AddListener(Cancelar);
    }

    private void Aplicar()
    {
        ui.Save();
        SceneHelper.Load(sceneMenu.ToString());
    }
    private void Cancelar()
    {
        SceneHelper.Load(sceneMenu.ToString());
    }
}
