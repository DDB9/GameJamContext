using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmHUD : MonoBehaviour {

    private void FixedUpdate()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        
        // Cast a ray straight up.
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.up);

        // If it hits something...
        if (hit.collider != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("test");
            }
        }

    }
}
