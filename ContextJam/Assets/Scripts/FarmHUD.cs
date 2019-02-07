using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmHUD : MonoBehaviour
{
    public Collider2D localCollider;

    public GameObject HUD;
    public Vector3 mousePos; //To store mouse position

    public Transform itemImg; //The UI element I'm instantiating
    public Transform parentObj; //The UI Canvas

    Transform clone;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit = new RaycastHit();


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics2D.Raycast(ray.origin, ray.direction))
            {
                itemImg = this.transform.GetChild(0).GetChild(0);
                mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //Gets mouse position
                var NewIncrementElement = Instantiate(itemImg,
                                                  transform.position,
                                                  Quaternion.identity)
                                                  as RectTransform; //instantiates the UI element
                NewIncrementElement.anchoredPosition = (mousePos); //moves element to mouse position. 

                NewIncrementElement.SetParent(parentObj); //sets the element to be a child            }
            }
        }
    }
}
