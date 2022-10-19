using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
{
    public Transform parentAfterDrag;
    public Image image;

    public GameObject temp, moveClonePrefab, slot;
    public bool tutulabilir;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        DragDropManager.lastObject = this;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        tutulabilir = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.CompareTag("Direct"))
        {
            if (tutulabilir == false) return;
            temp = Instantiate(moveClonePrefab,transform.position, Quaternion.identity ,slot.transform);
        }
        
        if (gameObject.CompareTag("Right"))
        {
            if (tutulabilir == false) return;
            temp = Instantiate(moveClonePrefab,transform.position, Quaternion.identity ,slot.transform);
        }
        
        if (gameObject.CompareTag("Left"))
        {
            if (tutulabilir == false) return;
            temp = Instantiate(moveClonePrefab,transform.position, Quaternion.identity ,slot.transform);
        }
        
        if (gameObject.CompareTag("Jump"))
        {
            if (tutulabilir == false) return;
            temp = Instantiate(moveClonePrefab,transform.position, Quaternion.identity ,slot.transform);
        }
        
        if (gameObject.CompareTag("Press"))
        {
            if (tutulabilir == false) return;
            temp = Instantiate(moveClonePrefab,transform.position, Quaternion.identity ,slot.transform);
        }
    }
}
