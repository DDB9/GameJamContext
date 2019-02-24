using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tomato : MonoBehaviour, IInventoryItem {
    public string Name
    {
        get
        {
            return "Tomato";
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
        Debug.Log("OnDrop!");
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 1000))
        {
            Debug.Log("Hit!");
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Pickupable")
        {
            Destroy(other);
        }
    }
}
