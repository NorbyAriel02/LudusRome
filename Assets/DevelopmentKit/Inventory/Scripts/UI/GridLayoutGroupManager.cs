using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridLayoutGroupManager : MonoBehaviour
{
    public InventoryObject inventory;
    public GameObject Container;
    private void Awake()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector2 zise = rectTransform.rect.size;
        GridLayoutGroup glg = Container.GetComponent<GridLayoutGroup>();        
        glg.cellSize = new Vector2(zise.x/inventory.col, zise.y/inventory.row);
    }
}
