using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cropPlacer : MonoBehaviour
{
    private GridManager grid;

    public GameObject blueberry;
    public GameObject potato;
    public GameObject tomato;

    public StaminaHealthBarManager hungerBarScript;
    public float hungerRegain;

    public Image[] inventorySlots = new Image[4];

    // Start is called before the first frame update
    void Awake()
    {
        grid = FindObjectOfType<GridManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.transform.tag == "Interactable" 
                    && hitInfo.transform.tag != "Pickupable"
                    && hitInfo.transform.tag != "Occupied")
                {
                    Debug.DrawRay(GameObject.Find("Main Camera").transform.position, Vector3.forward);
                    PlaceCubeNear(hitInfo.point);
                }
                else return;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            EatFood();
        }
    }

    void PlaceCubeNear(Vector3 clickPoint)  // Define distance between crops with differently sized colliders on the prefabs?
    {
        // Places the object on the actual grid Gizmos
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);

        var firstInventorySlot = inventorySlots[0].transform.GetChild(0);
        var secondInventorySlot = inventorySlots[1].transform.GetChild(0);
        var thirdInventorySlot = inventorySlots[2].transform.GetChild(0);
        var fourthInventorySlot = inventorySlots[3].transform.GetChild(0);

        // Checks what item is in the currently selected slot.
        if (CharacterControls.currentSelected == 0)
        {
            if (firstInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {
                Collider[] hitColliders = Physics.OverlapBox(finalPosition, Vector3.one, Quaternion.identity);
                foreach (Collider col in hitColliders)
                {
                    if (col.tag == "Border" || col.tag == "Pickupable")
                    {
                        Debug.Log("Collision detected!");
                    }
                }

                Instantiate(blueberry, finalPosition, Quaternion.identity);
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(0);
            }

            if (firstInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                Instantiate(potato, finalPosition, Quaternion.identity);
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(0);
            }

            if (firstInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                Instantiate(tomato, finalPosition, Quaternion.identity);
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(0);
            }

        }

        if (CharacterControls.currentSelected == 1)
        {
            if (secondInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {
                Instantiate(blueberry, finalPosition, Quaternion.identity);
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(1);
            }

            if (secondInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                Instantiate(potato, finalPosition, Quaternion.identity);
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(1);
            }

            if (secondInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                Instantiate(tomato, finalPosition, Quaternion.identity);
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(1);
            }
        }

        if (CharacterControls.currentSelected == 2)
        {
            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {
                Instantiate(blueberry, finalPosition, Quaternion.identity);
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(2);
            }

            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                Instantiate(potato, finalPosition, Quaternion.identity);
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(2);
            }

            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                Instantiate(tomato, finalPosition, Quaternion.identity);
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(2);
            }
        }

        if (CharacterControls.currentSelected == 3)
        {
            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {
                Instantiate(blueberry, finalPosition, Quaternion.identity);
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(Inventory.mItems.Count - 1);
            }

            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                Instantiate(potato, finalPosition, Quaternion.identity);
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(Inventory.mItems.Count - 1);
            }

            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                Instantiate(tomato, finalPosition, Quaternion.identity);
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(Inventory.mItems.Count - 1);
            }
        }
    }

    void EatFood()
    {
        var firstInventorySlot = inventorySlots[0].transform.GetChild(0);
        var secondInventorySlot = inventorySlots[1].transform.GetChild(0);
        var thirdInventorySlot = inventorySlots[2].transform.GetChild(0);
        var fourthInventorySlot = inventorySlots[3].transform.GetChild(0);

        if (CharacterControls.currentSelected == 0)
        {
            if (firstInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {

                hungerBarScript.hunger += hungerRegain;
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(0);
            }

            if (firstInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                hungerBarScript.hunger += hungerRegain;
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(0);
            }

            if (firstInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                hungerBarScript.hunger += hungerRegain;
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(0);
            }

        }
        if (CharacterControls.currentSelected == 1)
        {
            if (secondInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {

                hungerBarScript.hunger += hungerRegain;
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(1);
            }

            if (secondInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                hungerBarScript.hunger += hungerRegain;
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(1);
            }

            if (secondInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                hungerBarScript.hunger += hungerRegain;
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(1);
            }

        }
        if (CharacterControls.currentSelected == 2)
        {
            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {

                hungerBarScript.hunger += hungerRegain;
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(2);
            }

            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                hungerBarScript.hunger += hungerRegain;
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(2);
            }

            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                hungerBarScript.hunger += hungerRegain;
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(2);
            }

        }
        if (CharacterControls.currentSelected == 3)
        {
            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {

                hungerBarScript.hunger += hungerRegain;
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(3);
            }

            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                hungerBarScript.hunger += hungerRegain;
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(3);
            }

            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                hungerBarScript.hunger += hungerRegain;
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(3);
            }

        }

    }
}
