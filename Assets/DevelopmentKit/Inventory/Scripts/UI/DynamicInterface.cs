using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DynamicInterface : UserInterface
{
    public GridLayoutGroup gridLayoutGroup;
    public GameObject SlotPrefab;
    public override void CreateSlots()
    {
        gridLayoutGroup.cellSize = new Vector2(sizeSlot, sizeSlot);
        for (int x = 0; x < inventory.row; x++)
        {
            for (int y = 0; y < inventory.col; y++)
            {
                var obj = Instantiate(SlotPrefab, Vector3.zero, Quaternion.identity, transform);
                var button = ChildrenController.GetChildWithTag(obj, "Button");
                inventory.GetSlot(x, y).x = x;
                inventory.GetSlot(x, y).y = y;
                ResetButtonSlot(button);
                AddEvent(button, EventTriggerType.PointerDown, delegate { PointerDown(obj); });
                AddEvent(button, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
                AddEvent(button, EventTriggerType.PointerExit, delegate { OnExit(obj); });
                inventory.GetSlot(x, y).slotDisplay = obj;                
            }
        }
    }
    public override void CreateItemToSlot(Transform button, Item item)
    {
        var itemObj = Instantiate(ItemPrefab, button.position, Quaternion.identity, button);
        itemObj.GetComponent<CollectedItem>().data = item;
        itemObj.GetComponent<Image>().sprite = inventory.database.ItemObjects[item.Id].uiDisplay;
        itemObj.GetComponent<RectTransform>().sizeDelta = new Vector2(gridLayoutGroup.cellSize.x * item.columsWide, gridLayoutGroup.cellSize.y * item.rowsHigh);
    }
    public override bool CreateItemToMouse(Item item)
    {
        if (MouseData.goItemOnCursor == null)
        {
            var itemObj = Instantiate(ItemPrefab, father.position, Quaternion.identity, father);
            itemObj.GetComponent<CollectedItem>().data = item;
            itemObj.GetComponent<Image>().sprite = inventory.database.ItemObjects[item.Id].uiDisplay;
            itemObj.GetComponent<RectTransform>().sizeDelta = new Vector2(gridLayoutGroup.cellSize.x * item.columsWide, gridLayoutGroup.cellSize.y * item.rowsHigh);
            SetItemCursor(itemObj);
            return true;
        }
        return false;

    }
    protected override void SetPosition(RectTransform rect, Item item)
    {
        rect.sizeDelta = new Vector2(gridLayoutGroup.cellSize.x * item.columsWide, gridLayoutGroup.cellSize.y * item.rowsHigh);
        rect.anchoredPosition = new Vector2(-rect.sizeDelta.x / 2, rect.sizeDelta.y / 2);
    }
    protected override void ResetButtonSlot(GameObject Button)
    {
        var rectChild = Button.GetComponent<RectTransform>();
        rectChild.sizeDelta = new Vector2(gridLayoutGroup.cellSize.x, gridLayoutGroup.cellSize.y);
        rectChild.anchoredPosition = new Vector2(-rectChild.sizeDelta.x / 2, rectChild.sizeDelta.y / 2);
    }

    protected override void ResetBGSlot(GameObject slot)
    {
        GameObject imagen = ChildrenController.GetChildWithTag(slot, "Imagen");
        var rectChild = imagen.GetComponent<RectTransform>();
        rectChild.sizeDelta = new Vector2(gridLayoutGroup.cellSize.x, gridLayoutGroup.cellSize.y);
        rectChild.anchoredPosition = new Vector2(-rectChild.sizeDelta.x / 2, rectChild.sizeDelta.y / 2);
        imagen.GetComponent<Image>().color = colorAlpha;
    }
}
