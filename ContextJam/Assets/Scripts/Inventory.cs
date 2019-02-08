using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int slots = 4;

    private List<IInventoryItem> mItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;

    public void AddItem(IInventoryItem item)
    {
        if (mItems.Count < slots)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;
                mItems.Add(item);

                item.OnPickup();

                ItemAdded?.Invoke(this, new InventoryEventArgs(item));
            }
        }
    }

    public void RemoveItem(IInventoryItem item)
    {
        Debug.Log("Remove Item");

        if (mItems.Contains(item))
        {
            Debug.Log("Contains Item");

            mItems.Remove(item);
            item.OnDrop();

            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider != null) collider.enabled = true;
            ItemRemoved?.Invoke(this, new InventoryEventArgs(item));
        }
    }
}
