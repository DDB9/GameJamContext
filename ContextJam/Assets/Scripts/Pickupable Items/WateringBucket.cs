using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WateringBucket : MonoBehaviour
{
    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform inventoryPanel = transform.Find("Inventory");
        Image firstSlot = inventoryPanel.GetChild(0).GetComponent<Image>();
        Image secondSlot = inventoryPanel.GetChild(1).GetComponent<Image>();
        Image thirdSlot = inventoryPanel.GetChild(2).GetComponent<Image>();
        Image fourthSlot = inventoryPanel.GetChild(3).GetComponent<Image>();
        foreach(Transform slot in inventoryPanel)
        {
            if (!firstSlot.enabled)  // If the first slot has been selected.
            {
                Image item = firstSlot.transform.GetChild(0).GetComponent<Image>();
                // Get item sprite name, activate custom method function.
            }
        }
    }
}
