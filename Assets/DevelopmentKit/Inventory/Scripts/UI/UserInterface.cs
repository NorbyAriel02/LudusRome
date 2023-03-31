using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Linq;
using System;
using static UnityEditor.Progress;

[RequireComponent(typeof(EventTrigger))]
public abstract class UserInterface : MonoBehaviour
{
    public Color colorSlotFilled;
    public Color colorSlotFilledOver;
    public Color colorBlue;
    public Color colorAlpha;
    public float sizeSlot;    
    public GameObject ItemPrefab;
    public InventoryObject inventory;
    private InventorySlot afterSlot;
    protected Transform father;    
    private void Start()
    {
        inventory.Load();
        CreateSlots();
        SetEventSlots();
        ShowItems();
        father = GetFatherMaster(transform);
    }
    public void OnEnable()
    {
        
    }
    private void Update()
    {
        if (MouseData.goItemOnCursor != null)
        {
            MouseData.rectItemOnCursor.position = new Vector3((Input.mousePosition.x - (MouseData.rectItemOnCursor.sizeDelta.x / 2)), (Input.mousePosition.y + (MouseData.rectItemOnCursor.sizeDelta.y / 2)), Input.mousePosition.z);
        }
    }
    private void OnDestroy()
    {
        inventory.Save();
    }
    private Transform GetFatherMaster(Transform child)
    {
        Transform father = child.parent;

        Canvas c = father.GetComponent<Canvas>();

        if (father != null)
        {
            if (c == null)
                return GetFatherMaster(father);
        }

        return father;
    }
    private void SetEventSlots()
    {
        for (int x = 0; x < inventory.row; x++)
        {
            for (int y = 0; y < inventory.col; y++)
            {
                inventory.GetSlot(x, y).parent = this;                
                inventory.GetSlot(x, y).onAfterUpdated += OnSlotUpdate;
            }
        }
        AddEvent(gameObject, EventTriggerType.PointerEnter, delegate { OnEnterInterface(gameObject); });
        AddEvent(gameObject, EventTriggerType.PointerExit, delegate { OnExitInterface(gameObject); });
    }
    public abstract void CreateSlots();
    
    /*Se llama desde el load 
     * y creo que cuando se habre el inventario*/
    private void ShowItems()
    {
        for (int x = 0; x < inventory.row; x++)
        {
            for (int y = 0; y < inventory.col; y++)
            {
                if (inventory.GetSlot(x, y).item.Id != -1)
                {
                    GameObject button = ChildrenController.GetChildWithTag(inventory.GetSlot(x, y).slotDisplay, "Button");
                    CreateItemToSlot(button.transform, inventory.GetSlot(x, y).item);
                    SetButtonSlot(inventory.GetSlot(x, y).item, inventory.GetSlot(x, y).slotDisplay);
                    SetFeedbackVisual(inventory.GetSlot(x, y).item, inventory.GetSlot(x, y).slotDisplay);                    
                }
            }
        }
    }
    public abstract void CreateItemToSlot(Transform button, Item item);    
    public virtual bool CreateItemToMouse(Item item)
    {
        if (MouseData.goItemOnCursor == null)
        {
            var itemObj = Instantiate(ItemPrefab, father.position, Quaternion.identity, father);
            SetItemCursor(itemObj);
            return true;
        }
        return false;
    }
    public void OnSlotUpdate(InventorySlot slot)
    {
        GameObject button = ChildrenController.GetChildWithTag(slot.slotDisplay, "Button");
        GameObject child = ChildrenController.GetChild(button);
        if (slot.item.Id != -1 && child == null)
        {
            CreateItemToSlot(button.transform, slot.item);
            SetButtonSlot(slot.item, slot.slotDisplay);
            SetFeedbackVisual(slot.item, slot.slotDisplay);
        }
    }    
    protected void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        if (!trigger) { Debug.LogWarning("No EventTrigger component found!"); return; }
        var eventTrigger = new EventTrigger.Entry {eventID = type};
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }
    public void OnEnterInterface(GameObject obj)
    {
        MouseData.interfaceMouseIsOver = obj.GetComponent<UserInterface>();
    }
    public void OnExitInterface(GameObject obj)
    {
        //No funciona, se acciona cuando el puntero pasa sobre un slot
        //hay que buscar una alternativa de cambio        
        MouseData.interfaceMouseIsOver = null;
    }
    #region comment
    /*Estados 
      puntero sin item
            > click en slot sin objeto
            > click en slot con objeto
      puntero con item
            > click en slot sin objeto
            > click en slot con objeto
    */
    #endregion
    public void PointerDown(GameObject obj)
    {        
        GameObject button = ChildrenController.GetChildWithTag(obj, "Button");        
        if (MouseData.goItemOnCursor != null)
        {
            CollectedItem item = MouseData.goItemOnCursor.GetComponent<CollectedItem>();
            InventorySlot slot = inventory.GetSlot(obj);
            if (inventory.IsSpaceAvailableReverse(item.data, slot.x, slot.y))
            {   
                inventory.ChangeItemLocation(item.data, slot.x, slot.y, slot.amount);
                SetButtonSlot(item.data, obj);
                SetFeedbackVisual(item.data, obj);             
                Destroy(MouseData.goItemOnCursor);                
            }
        }
        else
        {          
            GameObject itemObj = ChildrenController.GetChild(button);
            if (itemObj != null)
            {                
                SetItemCursor(itemObj);
                afterSlot = inventory.GetSlot(obj);
                CollectedItem item = MouseData.goItemOnCursor.GetComponent<CollectedItem>();
                inventory.RemoveItem(item.data, afterSlot.x, afterSlot.y);                
                ResetButtonSlot(button);
                ResetBGSlot(obj);
            }
        }
    }
    protected void SetItemCursor(GameObject item)
    {        
        if(item != null)
        {
            item.transform.SetParent(father);
            MouseData.goItemOnCursor = item;
            MouseData.rectItemOnCursor = MouseData.goItemOnCursor.GetComponent<RectTransform>();
        }
        else
        {
            MouseData.goItemOnCursor = null;
            MouseData.rectItemOnCursor = null;
        }        
    }
    #region comment
    /*Al Salir el puntero al area de un slot 
     verificamos si el puntero tiene item, 
    -->SI NO tiene item no hacemos nada
    -->si el puntero tiene item verificamos si el slot tiene item
        -->SI NO tiene item el slot reseteamos el feedback visual del slot
        -->SI el slot tiene item dejamos el slot con color colorSlotFilled

    esto creo que esta joya
    */
    #endregion
    public void OnExit(GameObject obj)
    {   
        if (MouseData.goItemOnCursor != null)
        {
            GameObject button = ChildrenController.GetChildWithTag(obj, "Button");
            GameObject itemObj = ChildrenController.GetChild(button);
            if (itemObj == null)
            {                
                ResetButtonSlot(button);
                ResetBGSlot(obj);
            }
            else
            {
                SetBGSlotFilled(obj);
            }            
        }            
    }
    #region commet
    /*Al entrar el puntero al area de un slot 
     verificamos si el puntero tiene item, 
    -->si no tiene item no hacemos nada
    -->si tiene item verificamos si entra en las celdas disponible
        -->SI NO entra le mostramos al usuario el BG rojo de no se puede
        -->SI entre le mostramos al usuario el BG azul de que puede dejar el item ahi si hace click
    */
    #endregion
    public void OnEnter(GameObject obj)
    {        
        if (MouseData.goItemOnCursor != null)
        {
            InventorySlot slot = inventory.GetSlot(obj);
            if (slot.item.Id != -1)
            {
                SetBGSlotFilledOver(obj);
            }
            else
            {
                GameObject button = ChildrenController.GetChildWithTag(obj, "Button");                
                CollectedItem item = MouseData.goItemOnCursor.GetComponent<CollectedItem>();                
                /*El item y el slot pueden tener coordenadas diferentes
                 porque el item puede que haya pertenecido a un slot diferente antes
                esto esta ok*/
                if (inventory.IsSpaceAvailableReverse(item.data, slot.x, slot.y))
                {
                    SetAvailableSlot(item.data, obj);
                }
            }            
        }
    }    
    private void SetButtonSlot(Item item, GameObject slot)
    {
        GameObject button = ChildrenController.GetChildWithTag(slot.gameObject, "Button");
        var rectChild = button.GetComponent<RectTransform>();
        SetPosition(rectChild, item);
    }
    private void SetFeedbackVisual(Item item, GameObject slot)
    {
        GameObject imagen = ChildrenController.GetChildWithTag(slot.gameObject, "Imagen");
        var rectChild = imagen.GetComponent<RectTransform>();
        SetPosition(rectChild, item);
        imagen.GetComponent<Image>().color = colorSlotFilled;
    }
    protected abstract void SetPosition(RectTransform rect, Item item);    
    private void SetAvailableSlot(Item item, GameObject slot)
    {
        GameObject imagen = ChildrenController.GetChildWithTag(slot, "Imagen");
        var rectChild = imagen.GetComponent<RectTransform>();
        SetPosition(rectChild, item);
        imagen.GetComponent<Image>().color = colorBlue;
    }
    protected virtual void ResetButtonSlot(GameObject Button)
    {        
        
    }
    protected virtual void ResetBGSlot(GameObject slot)
    {
        
    }
    private void SetBGSlotFilled(GameObject slot)
    {
        GameObject imagen = ChildrenController.GetChildWithTag(slot, "Imagen");        
        imagen.GetComponent<Image>().color = colorSlotFilled;
    }
    private void SetBGSlotFilledOver(GameObject slot)
    {
        GameObject imagen = ChildrenController.GetChildWithTag(slot, "Imagen");
        imagen.GetComponent<Image>().color = colorSlotFilledOver;
    }
}



