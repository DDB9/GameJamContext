using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvSlot : MonoBehaviour
{
    public GameObject HUD;
    public Vector3 mousePos; //To store mouse position

    public Transform itemImg; //The UI element I'm instantiating
    public Transform parentObj; //The UI Canvas

    Transform clone;

    private void Update()
    {

    }

    public void Select()
    {
        itemImg = this.transform.GetChild(0).GetChild(0);
        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y); //Gets mouse position
        var NewIncrementElement = Instantiate(itemImg,
                                          transform.position,
                                          Quaternion.identity)
                                          as RectTransform; //instantiates the UI element
        NewIncrementElement.anchoredPosition = (mousePos); //moves element to mouse position. 

        NewIncrementElement.SetParent(parentObj); //sets the element to be a child
    }
}
