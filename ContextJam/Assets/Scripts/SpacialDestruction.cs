using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacialDestruction : MonoBehaviour
{
    public Inventory inventory;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Occupied"))
        {
            var parent = this.transform.parent;
            IInventoryItem item = parent.GetComponent<IInventoryItem>();

            Debug.Log(parent.name);
            if (item != null)
            {
                inventory.AddItem(item);
            }
            Destroy(parent);
            
        }
    }
}
