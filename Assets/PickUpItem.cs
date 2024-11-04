 
using UnityEngine;
using UnityEngine.EventSystems;

public class PickUpItem : MonoBehaviour, IPointerClickHandler
{   
    private Inventory inventory;
    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            inventory.AddItem("Add ArmorVest Item");
            gameObject.SetActive(false);
        }
    }
}
