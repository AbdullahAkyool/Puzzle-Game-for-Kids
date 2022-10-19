using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardsSlot : MonoBehaviour,IDropHandler
{
    public Inventory inventory;

    private DragableItem _dragableItem;

    private void Awake()
    {
        _dragableItem = FindObjectOfType<DragableItem>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log(DragDropManager.lastObject);
        
        Debug.Log(_dragableItem.tutulabilir);
        
        
        if (transform.childCount == 0)
        {
            DragableItem dragableItem = eventData.pointerDrag.GetComponent<DragableItem>();
            dragableItem.parentAfterDrag = transform;
            
            Debug.Log("slota girdi");
            Debug.Log(_dragableItem.tutulabilir);

            if (DragDropManager.lastObject != null)
            {
                inventory.PlayerMoveCards.Add(DragDropManager.lastObject.gameObject);
                    
                DragDropManager.lastObject = null;
            }
        }

        
        // for (int i = 0; i < inventory.slots.Length; i++)
        // {
        //         if (inventory.isFull[i] == true)
        //         {
        //             //üst üste gelme engellenecek
        //         }
        //
        //         if (inventory.isFull[i] == false)
        //         {
        //             if (DragDropManager.lastObject != null)
        //             {
        //                 inventory.PlayerMoveCards.Add(DragDropManager.lastObject.gameObject);
        //             
        //                 DragDropManager.lastObject = null;
        //             
        //             }
        //             inventory.isFull[i] = true;
        //             break;
        //         }
        //     
        // }

        // if(eventData.pointerDrag != null)
        // {
        //     eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition; 
        // }
    }
}
