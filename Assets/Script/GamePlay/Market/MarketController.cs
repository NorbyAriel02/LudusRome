using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum MoveIndex { Next = 1, After = -1 }
public class MarketController : MonoBehaviour
{
    public delegate void ChangeGladitor(Gladiator gladiator);    
    public static ChangeGladitor OnChange;
    public GameObject prefabGladiator;
    public Transform pull;
    public int countPull;
    public List<Button> buttonList;
    public Transform viewerGladiator;
    public Transform ludus;
    private List<GameObject> listPull;
    private int index = 0;
    public Gladiator currentGladiator = null;
    void Start()
    {
        listPull = ObjectHelper.GetPull(prefabGladiator, countPull, transform);
        SetOnGladiator();
        buttonList[0].onClick.AddListener(Back);
        buttonList[1].onClick.AddListener(Next);
        buttonList[2].onClick.AddListener(After);
        buttonList[3].onClick.AddListener(Buy);
    }
    private void Back()
    {
        SceneHelper.Load("Mercado");
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
        int IndexBuy = index;
        ChangeGladiator(MoveIndex.Next);
        GameObject go = listPull[IndexBuy];
        go.transform.SetParent(ludus);
        listPull.Remove(go);
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
        int indexOff = index;
        index = index + (int)move;
        index = (index < 0) ? (index = countPull - 1) : (index >= countPull) ? 0 : index;
        SetOffGladiator(indexOff);
        SetOnGladiator(index);
        currentGladiator = listPull[index].GetComponent<StartGladiator>().gladiator;
        OnChange?.Invoke(currentGladiator);
    }
}
