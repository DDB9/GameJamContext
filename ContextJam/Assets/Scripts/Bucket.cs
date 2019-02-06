using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour, IInventoryItem
{
    public string name
    {
        get
        {
            return "Bucket";
        }
    }

    public Sprite _Image = null;
    public Sprite image
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
}
