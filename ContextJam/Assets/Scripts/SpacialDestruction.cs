using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacialDestruction : MonoBehaviour
{
    public Inventory inventory;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Occupied"))
        {
            Transform parent = this.transform.parent;
            IInventoryItem item = parent.GetComponent<IInventoryItem>();

            if (item != null)
            {
                inventory.AddItem(item);
            }
            Destroy(parent);
            
        }
    }
}
