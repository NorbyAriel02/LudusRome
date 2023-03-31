using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StaticInterface : UserInterface
{
    public GameObject[] slots;
    public override void CreateSlots()
    {
        int count = 0;
        for(int i = 0; i < inventory.row; i++)
        {
            for(int j = 0; j < inventory.col; j++)
            {
                var slot = slots[count];
                var button = ChildrenController.GetChildWithTag(slot, "Button");
                inventory.GetSlot(i, j).x = i;
                inventory.GetSlot(i, j).y = j;
                ResetButtonSlot(button);
                AddEvent(button, EventTriggerType.PointerDown, delegate { PointerDown(slot); });
                AddEvent(button, EventTriggerType.PointerEnter, delegate { OnEnter(slot); });
                AddEvent(button, EventTriggerType.PointerExit, delegate { OnExit(slot); });
                inventory.GetSlot(i, j).slotDisplay = slot;
                count++;
            }
        }
    }
    public override void CreateItemToSlot(Transform button, Item item)
    {        
        var itemObj = Instantiate(ItemPrefab, button.position, Quaternion.identity, button);
        itemObj.GetComponent<CollectedItem>().data = item;
        itemObj.GetComponent<Image>().sprite = inventory.database.ItemObjects[item.Id].uiDisplay;
        itemObj.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeSlot * item.columsWide, sizeSlot * item.rowsHigh);
    }
    public override bool CreateItemToMouse(Item item)
    {
        if (MouseData.goItemOnCursor == null)
        {
            var itemObj = Instantiate(ItemPrefab, father.position, Quaternion.identity, father);
            itemObj.GetComponent<CollectedItem>().data = item;
            itemObj.GetComponent<Image>().sprite = inventory.database.ItemObjects[item.Id].uiDisplay;
            itemObj.GetComponent<RectTransform>().sizeDelta = new Vector2(sizeSlot * item.columsWide, sizeSlot * item.rowsHigh);
            SetItemCursor(itemObj);

            return true;
        }
        return false;
    }
    protected override void SetPosition(RectTransform rect, Item item)
    {
        rect.sizeDelta = new Vector2(sizeSlot * item.columsWide, sizeSlot * item.rowsHigh);
        rect.anchoredPosition = new Vector2(-rect.sizeDelta.x / 2, rect.sizeDelta.y / 2);
    }
    protected override void ResetButtonSlot(GameObject Button)
    {
        var rectChild = Button.GetComponent<RectTransform>();
        rectChild.sizeDelta = new Vector2(sizeSlot, sizeSlot);
        rectChild.anchoredPosition = new Vector2(-rectChild.sizeDelta.x / 2, rectChild.sizeDelta.y / 2);
    }

    protected override void ResetBGSlot(GameObject slot)
    {
        GameObject imagen = ChildrenController.GetChildWithTag(slot, "Imagen");
        var rectChild = imagen.GetComponent<RectTransform>();
        rectChild.sizeDelta = new Vector2(sizeSlot, sizeSlot);
        rectChild.anchoredPosition = new Vector2(-rectChild.sizeDelta.x / 2, rectChild.sizeDelta.y / 2);
        imagen.GetComponent<Image>().color = colorAlpha;
    }
}
