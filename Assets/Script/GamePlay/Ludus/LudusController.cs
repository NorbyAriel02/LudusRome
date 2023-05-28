using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LudusController : MonoBehaviour
{
    public delegate void ChangeGladitor(GladiatorV2 gladiator);
    public static ChangeGladitor OnChange;
    public TMP_Text txtName;
    public EnumScene sceneBack;
    public Transform LudusGladiator;
    public List<Button> buttonList;
    public Transform viewerGladiator;
    public Transform ludus;
    public GameObject panelEquipment;
    private List<GameObject> listPull;
    private int index = 0;
    private GladiatorV2 currentGladiator = null;
    private GameObject currentItem = null;
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {

    }
    void Start()
    {
        listPull = ChildrenController.GetListChildren(LudusGladiator.gameObject);
        buttonList[0].onClick.AddListener(Back);
        buttonList[1].onClick.AddListener(Next);
        buttonList[2].onClick.AddListener(After);
        buttonList[3].onClick.AddListener(OpenCloseEquipment);
        Load();
    }
    private void Load()
    {
        ChangeGladiator(MoveIndex.Next);
    }
    private void Back()
    {
        SceneHelper.Load(sceneBack.ToString());
    }
    private void Next()
    {
        ChangeGladiator(MoveIndex.Next);
    }
    private void After()
    {
        ChangeGladiator(MoveIndex.After);
    }
    private void OpenCloseEquipment()
    {        
        panelEquipment.SetActive(!panelEquipment.activeSelf);
    }

    private void SetOffGladiator(int index)
    {
        listPull[index].transform.position = transform.position;
        listPull[index].SetActive(false);
    }
    private void SetOnGladiator(int index = 0)
    {
        listPull[index].transform.position = viewerGladiator.position;
        listPull[index].SetActive(true);
    }

    private void ChangeGladiator(MoveIndex move)
    {
        if (listPull.Count <= 0)
            listPull = ChildrenController.GetListChildren(LudusGladiator.gameObject);

        if (currentItem == null)
            currentItem = listPull[0];

        index = listPull.IndexOf(currentItem);

        int indexOff = index;
        index = index + (int)move;
        index = (index < 0) ? (index = listPull.Count - 1) : (index >= listPull.Count) ? 0 : index;
        SetOffGladiator(indexOff);
        SetOnGladiator(index);
        currentItem = listPull[index];
        currentGladiator = currentItem.GetComponent<StartGladiator>().gladiator;
        txtName.text = currentGladiator.data.name;
        OnChange?.Invoke(currentGladiator);
    }
}
