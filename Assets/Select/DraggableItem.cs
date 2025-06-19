using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Transform m_Transform { get; set; }
    public RectTransform rectTransform { get; set; }
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private Outline line;
    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
        rectTransform = GetComponent<RectTransform>();
        canvas = m_Transform.GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
        line = GetComponent<Outline>();
    }
    private void OnEnable()
    {
        line.enabled = false;
    }
    private void OnDisable()
    {
        line.enabled = false;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.5f;
        m_Transform = transform.parent;
        rectTransform.SetParent(canvas.transform);
        rectTransform.SetAsLastSibling(); 
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor; 
    }

    public void OnEndDrag(PointerEventData eventData)
    { 
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        rectTransform.SetParent(m_Transform);     }
    public void PickEnterItem()
    {
        line.enabled = true;
    }
    public void PickEndItem()
    {
        line.enabled = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PickEnterItem();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        PickEndItem();
    }
}
