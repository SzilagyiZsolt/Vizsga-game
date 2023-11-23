using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public Image image;
    public Color selectedColor, notSelectedColor;
    public InventoryManager inventoryManager;
    public GameObject buttons;
    public void Select()
    {
        image.color=selectedColor;
    }
    public void Deselected(PointerEventData eventData) 
    {
        if (transform.childCount == 1)
        {
            buttons.transform.position = Input.mousePosition;
            buttons.SetActive(true);
        }
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
              InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
              inventoryItem.parentAfterDrag = transform;
        }

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button==PointerEventData.InputButton.Right)
        {
            Deselected(eventData);
        }
    }
}
