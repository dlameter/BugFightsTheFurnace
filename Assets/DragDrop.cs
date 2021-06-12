using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public UnityEvent onDrop;
    private Canvas canvas;
    private CanvasGroup group;
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = this.GetComponent<RectTransform>();
        canvas = this.GetComponentInParent<Canvas>();
        group = this.GetComponent<CanvasGroup>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("OnPointerDown");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Debug.Log("OnBeginDrag");
        group.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Debug.Log("OnEndDrag");
        group.blocksRaycasts = true;
        onDrop.Invoke();
    }
}
