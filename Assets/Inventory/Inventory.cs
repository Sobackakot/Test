using System.Collections;
using System.Collections.Generic; 
using UnityEngine;

namespace Inventory_
{
    public class Inventory : MonoBehaviour
    {
        private List<Slot> slots = new List<Slot>();
        [SerializeField] private GameObject prefabItem;

        private void Awake()
        {
            slots.AddRange(FindObjectsOfType<Slot>(true));
        }
        public void AddItem()
        {
            for (short i = 0; i < slots.Count; i++)
            {
                if (slots[i].transform.childCount > 0) continue;
                GameObject newItem = Instantiate(prefabItem, slots[i].transform.position, Quaternion.identity);
                SetDataItem(newItem, i);
                return;
            }
        }
        public void RemoveItem()
        {
            
        }
        private void SetDataItem(GameObject newItem, short index)
        {
            Item item = newItem.transform.GetComponent<Item>();
            item.m_Transform = slots[index].transform;
            item.transform.SetParent(slots[index].transform);
            item.transform.localScale = Vector3.one;
            item.enabled = false;
            item.enabled = true;
        }

    }
}


