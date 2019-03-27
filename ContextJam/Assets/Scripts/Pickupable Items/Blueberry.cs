using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blueberry : MonoBehaviour, IInventoryItem 
{
    public string Name
    {
        get
        {
            return "Blueberry";
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
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Pickupable") 
        {
            Destroy(other);
        }
    }
}
