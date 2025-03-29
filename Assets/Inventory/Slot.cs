 
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Inventory_
{
    public class Slot : MonoBehaviour, IDropHandler
    {
        public short index { get; set; }
        private RectTransform m_RectTransform;
        private void Awake()
        {
            m_RectTransform = GetComponent<RectTransform>();
        }

        public void OnDrop(PointerEventData eventData)
        {
            Item item = eventData.pointerDrag.GetComponent<Item>();// взяли
            if (item == null) return;

            if (m_RectTransform.childCount > 0) //положили
            {
                Item otherItem = m_RectTransform.GetChild(0).GetComponent<Item>();
                if (otherItem != null) SwapItems(item, otherItem);
            }
            else
            {
                item.m_Transform = m_RectTransform;
                item.transform.SetParent(m_RectTransform);  // Ensure the item is visually moved to the slot 
            }
        }

        public void SwapItems(Item item, Item otherItem)
        {
            var tempt = item.m_Transform;

            item.m_Transform = otherItem.m_Transform;
            item.transform.SetParent(otherItem.m_Transform);

            otherItem.m_Transform = tempt;
            otherItem.transform.SetParent(tempt);
        }
    }
}

