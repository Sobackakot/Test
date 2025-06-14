using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableRegistry : MonoBehaviour
{
    public readonly List<DraggableItem> itemFromScreen = new();
    private void Awake()
    {
        itemFromScreen.AddRange(GetComponentsInChildren<DraggableItem>(false));
        Debug.Log(itemFromScreen.Count + " awake select objects");
    }
}
