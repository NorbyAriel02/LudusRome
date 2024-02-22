using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectBattleGladiator : MonoBehaviour
{
    public delegate void SelectBattleGladiatorEvent(GameObject go);
    public static SelectBattleGladiatorEvent OnSelectGladiator;
    public Button btnSelect;
    public GameObject Panel;
    public GameObject Gladiator;
    void Start()
    {
        btnSelect.onClick.AddListener(Select);
        Panel = ObjectHelper.GetParentWithComponent<LoadGladiatorsToList>(gameObject);
    }
    void Select()
    {        
        OnSelectGladiator?.Invoke(Gladiator);         
        Panel.SetActive(false);
    }
}
