 
using UnityEngine;
using UnityEngine.EventSystems; 

public class Item : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{   
    public Transform m_Transform {  get; set; }
    public RectTransform rectTransform { get; set; }
    private CanvasGroup canvasGroup;
    private Canvas canvas;

    private void OnEnable()
    {
        m_Transform = GetComponent<Transform>();
        rectTransform = GetComponent<RectTransform>();
        canvas = m_Transform.GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
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
        rectTransform.SetParent(m_Transform);   
    }
}
