using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmGrid : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Mouse entered the facility");
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("RELEASE");
        }
        if (other.tag == "Inventory Slot")
        {
            if (Input.GetMouseButtonUp(0))
            {
                Debug.Log("Test");
            }
        }
    }
}
