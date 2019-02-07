using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmHUD : MonoBehaviour {

    public Transform itemInvPos;

    private void FixedUpdate()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        
        // Cast a ray straight up.
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.up);

        // If it hits something...
        if (hit.collider != null && hit.collider.tag == "Inventory Slot")
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 temp = Input.mousePosition;
                temp.z = 10f; // Set this to be the distance you want the object to be placed in front of the camera.
                hit.collider.transform.position = temp;


            }
            if (Input.GetMouseButtonUp(0))
            {
                if (hit.collider == null)
                {
                    hit.collider.transform.position = itemInvPos.position;
                }
            }
        }
    }
}
