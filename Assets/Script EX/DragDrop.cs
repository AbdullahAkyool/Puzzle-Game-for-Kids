using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTransform;
    public Canvas canvas;
    private CanvasGroup canvasGroup;
    [SerializeField] private GameObject CommandParent;

    public GameObject moveClonePrefab;
    public GameObject temp;

    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)  ///Sürükleme başlatılmadan önce
    {
       // DragDropManager.lastObject = this;
        canvasGroup.blocksRaycasts = false;
    } 
    
    public void OnDrag(PointerEventData eventData)  ///Sürükleme meydana geldiğinde imleç hareketi ile
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    
    public void OnEndDrag(PointerEventData eventData)  /// Sürükleme sona erdiğinde
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {

        if (gameObject.CompareTag("Direct"))
        {
            temp = Instantiate(moveClonePrefab,transform.position, Quaternion.identity ,CommandParent.transform);
        }
        
        if (gameObject.CompareTag("Right"))
        {
            temp = Instantiate(moveClonePrefab,transform.position, Quaternion.identity ,CommandParent.transform);
        }
        
        if (gameObject.CompareTag("Left"))
        {
            temp = Instantiate(moveClonePrefab,transform.position, Quaternion.identity ,CommandParent.transform);
        }
        
        if (gameObject.CompareTag("Jump"))
        {
            temp = Instantiate(moveClonePrefab,transform.position, Quaternion.identity ,CommandParent.transform);
        }
        
        if (gameObject.CompareTag("Press"))
        {
            temp = Instantiate(moveClonePrefab,transform.position, Quaternion.identity ,CommandParent.transform);
        }
    }
}
