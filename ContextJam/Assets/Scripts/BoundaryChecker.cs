using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Put this script on (all) the red blocks that surround the crop.
public class BoundaryChecker : MonoBehaviour
{
   Inventory _inventory;

   void OnTriggerStay(Collider other) 
   {
        if (other.CompareTag("Occupied")) 
        {
            if (other.transform.parent.name == "Blueberry(Clone)") 
            {
                Destroy(other.transform.parent);
                _inventory.AddItem(GameObject.Find("Dummy Blueberry").GetComponent<IInventoryItem>());
            }
            else if (other.transform.parent.name == "Potato(Clone)")
            {
                Destroy(other.transform.parent);
                _inventory.AddItem(GameObject.Find("Dummy Potato").GetComponent<IInventoryItem>());
            }
            else if (other.transform.parent.name == "Tomato(Clone)") 
            {
                Debug.Log("Tomato here");
                Destroy(other.transform.parent);
                _inventory.AddItem(GameObject.Find("Dummy Tomato").GetComponent<IInventoryItem>());
            }
        }
    }
}
