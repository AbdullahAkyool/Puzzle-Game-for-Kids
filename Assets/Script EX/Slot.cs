using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler
{
    private Inventory inventory;


    private void Start()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)  /// Objenin üstüne bir şey bırakıldığında çağrılır
    {
        Debug.Log("slota girdi");
        
        for (int i = 0; i < inventory.slots.Length; i++)
        {
            if (inventory.isFull[i] == true)
            {
                //üst üste gelme engellenecek
            }

            if (inventory.isFull[i] == false)
            {
                
                
                if (DragDropManager.lastObject != null)
                {
                    inventory.PlayerMoveCards.Add(DragDropManager.lastObject.gameObject);
                    
                    DragDropManager.lastObject = null;
                    
                }
                inventory.isFull[i] = true;
                break;
            }
            
        }

        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }
}