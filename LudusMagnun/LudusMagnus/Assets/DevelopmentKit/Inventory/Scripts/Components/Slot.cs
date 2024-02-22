using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public delegate void MoveIten(GameObject item);
    public static MoveIten OnMoveItem;
    public delegate bool RecieveItem(Slot slot);
    public static RecieveItem OnRecieveItem;
    public int index;
    public int row;
    public int col;
    public bool isEmpty;    
    public List<ItemTypeObject> types;
    private ContainerUserInterface userInterface;
    private void Start()
    {
        GameObject go = ObjectHelper.GetParentWithComponent<ContainerUserInterface>(gameObject);
        userInterface = go.GetComponent<ContainerUserInterface>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (isEmpty)
                LinkItemToSlot();
            else
                SetItemToMouse();           
        }
    }
    private void SetItemToMouse()
    {        
        GameObject item = ChildrenController.GetChild(gameObject);
        if(MouseData.item != null)//valida si el mouse ya tiene un item en el puntero
        {
            if ((bool)OnRecieveItem?.Invoke(this))//valida si el slot acepta el item
            {
                RemoveItem(item);
                OnMoveItem?.Invoke(item);//envia su propio item a el cursor
                /*no es necesario validar en este punto si puede agregar el item, 
                 * siempre va ser si puede desde el slot*/
                AddItem(ChildrenController.GetChild(gameObject));
            }
        }       
        else
        {
            RemoveItem(item);
            OnMoveItem?.Invoke(item);//envia su propio item a el cursor
        }
    }
    private void LinkItemToSlot()
    {        
        GameObject item = ChildrenController.GetChild(gameObject);

        if ((bool)OnRecieveItem?.Invoke(this))
        {
            if (item != null)
                OnMoveItem?.Invoke(item);
            
            /*no es necesario validar en este punto si puede agregar el item, 
                 * siempre va ser si puede desde el slot*/
            AddItem(ChildrenController.GetChild(gameObject));
        }
    }
    void AddItem(GameObject item)
    {
        isEmpty = false;        
        userInterface.AddItem(item);
    }
    void RemoveItem(GameObject item)
    {
        isEmpty = true;         
        userInterface.RemoveItem(item);
    }
}