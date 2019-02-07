using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmHUD : MonoBehaviour 
{
    public Sprite bBerry;
    public Sprite potato;
    public Sprite tomato;

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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider>().tag == "Pickupable")
        {
            Transform farmHUD = transform.Find("Farm_HUD");
            foreach (Transform slot in farmHUD)
            {
                Image image = slot.GetChild(0).GetComponent<Image>();

                if (image != enabled)
                {
                    image.enabled = true;
                    if (collision.GetComponent<Image>().sprite.name == "Blueberry-Sprite")
                    {
                        image.sprite = bBerry;
                    }

                    break;
                }
            }
        }
    }
}
