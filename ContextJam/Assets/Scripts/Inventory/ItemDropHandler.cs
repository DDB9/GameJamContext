using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public Inventory _inventory;

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Drop!");

        RectTransform invPanel = transform as RectTransform;
        if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            IInventoryItem item = eventData.pointerDrag.gameObject.GetComponent<ItemDragHandler>().Item;
            if (item != null)
            {
                _inventory.RemoveItem(item);
                item.OnDrop();
            }
        }
    }
}
