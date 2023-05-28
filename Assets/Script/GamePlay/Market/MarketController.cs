using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum MoveIndex { Next = 1, After = -1 }
public class MarketController : MonoBehaviour
{
    public delegate void ChangeGladitor(GladiatorV2 gladiator);    
    public static ChangeGladitor OnChange;
    public EnumScene sceneBack;
    public GameObject prefabGladiator;
    public Transform pull;
    public int countPull;
    public List<Button> buttonList;
    public Transform viewerGladiator;
    public Transform ludus;
    public GameObject panelSell;
    public Image Avatar;
    public TMP_Text txtName;
    private List<GameObject> listPull;
    private int index = 0;
    private GladiatorV2 currentGladiator = null;
    private GameObject currentItem = null;
    private void OnEnable()
    {
        PanelSell.OnClose += Load;
    }
    private void OnDisable()
    {     
        PanelSell.OnClose -= Load;
    }
    void Start()
    {
        listPull = ObjectHelper.GetPull(prefabGladiator, countPull, transform);        
        buttonList[0].onClick.AddListener(Back);
        buttonList[1].onClick.AddListener(Next);
        buttonList[2].onClick.AddListener(After);
        buttonList[3].onClick.AddListener(Buy);
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
    private void Buy()
    {
        if (currentItem == null)
            return;

        Avatar.sprite = currentGladiator.data.avatarUI;
        txtName.text = "You bought " + Environment.NewLine + currentGladiator.data.name;
        currentItem.transform.SetParent(ludus);
        listPull.Remove(currentItem);
        currentItem.SetActive(false);
        currentItem = null;
        panelSell.SetActive(true);
    }

    private void SetOffGladiator(int index)
    {
        listPull[index].transform.SetParent(transform);
        listPull[index].transform.position = transform.position;
        listPull[index].SetActive(false);
    }
    private void SetOnGladiator(int index = 0)
    {
        listPull[index].transform.SetParent(viewerGladiator);
        listPull[index].transform.position = viewerGladiator.position;
        listPull[index].SetActive(true);
    }

    private void ChangeGladiator(MoveIndex move)
    {        
        if (listPull.Count <= 0)
        {
            OnChange?.Invoke(null);
            return;
        }            

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
        OnChange?.Invoke(currentGladiator);
    }
}
