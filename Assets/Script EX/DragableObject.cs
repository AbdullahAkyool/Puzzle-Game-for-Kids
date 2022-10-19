using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragableObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector3 point;
    public bool isDrag;

    public void Start()
    {
        //DragDropManager.lastObject = this;
    }
    
    public void OnPointerDown(PointerEventData eventData) {
        isDrag = true;
    }
    public void OnPointerUp(PointerEventData eventData) {
        isDrag = false;
    }
    

    public void SelectObject()
    {
        isDrag = true;
    }
    
    public void SnapObject()
    {
        isDrag = false;
    }
    public void Update()
    {
        if (isDrag) {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }


}
