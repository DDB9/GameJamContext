using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : MonoBehaviour, IInventoryItem
{
    public string Name
    {
        get
        {
            return "Potato";
        }
    }

    public Sprite _Image = null;
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }
    public void OnPickup()
    {
        gameObject.SetActive(false);

        
    }

    public void OnDrop()
    {
        // shit that happens when the player presses x or something.
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Pickupable")
        {
            Destroy(other);
        }
    }

   
}
