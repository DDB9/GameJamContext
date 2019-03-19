using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour

{
    public Inventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickupable"))
        {
            IInventoryItem item = other.GetComponent<IInventoryItem>();
            if (item != null)
            {
                inventory.AddItem(item);
            }
        }
    }

  
}
