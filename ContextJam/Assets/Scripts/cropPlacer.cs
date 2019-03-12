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
    public float hungerRegainPotato;
    public float hungerRegainTomato;
    public float hungerRegainBerry;


    public int tomatoCounter = 0;
    public int potatoCounter = 0;
    public int berryCounter = 0;

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
                BerryCount();
                hungerBarScript.hunger += hungerRegainBerry;
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(0);
            }

            if (firstInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                PotatoCount();
                hungerBarScript.hunger += hungerRegainPotato;
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(0);
            }

            if (firstInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                TomatoCount();
                hungerBarScript.hunger += hungerRegainTomato;
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(0);
            }

        }
        if (CharacterControls.currentSelected == 1)
        {
            if (secondInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {
                BerryCount();
                hungerBarScript.hunger += hungerRegainBerry;
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(1);
            }

            if (secondInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                PotatoCount();
                hungerBarScript.hunger += hungerRegainPotato;
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(1);
            }

            if (secondInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                TomatoCount();
                hungerBarScript.hunger += hungerRegainTomato;
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(1);
            }

        }
        if (CharacterControls.currentSelected == 2)
        {
            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {
                BerryCount();
                hungerBarScript.hunger += hungerRegainBerry;
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(2);
            }

            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                PotatoCount();
                hungerBarScript.hunger += hungerRegainPotato;
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(2);
            }

            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                TomatoCount();
                hungerBarScript.hunger += hungerRegainTomato;
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(2);
            }

        }
        if (CharacterControls.currentSelected == 3)
        {
            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {
                BerryCount();
                hungerBarScript.hunger += hungerRegainBerry;
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(3);
            }

            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                PotatoCount();
                hungerBarScript.hunger += hungerRegainPotato;
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(3);
            }

            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                TomatoCount();
                hungerBarScript.hunger += hungerRegainTomato;
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(3);
            }

        }

    }

    void PotatoCount()
    {
        potatoCounter += 1;
        if (tomatoCounter > 0) tomatoCounter -= 1;
        else tomatoCounter = 0;
        if (berryCounter > 0) berryCounter -= 1;
        else berryCounter = 0;
    }
    void TomatoCount()
    {
        if (potatoCounter > 0) potatoCounter -= 1;
        else potatoCounter = 0;
        tomatoCounter += 1;
        if (berryCounter > 0) berryCounter -= 1;
        else berryCounter = 0;
    }
    void BerryCount()
    {
        if (potatoCounter > 0) potatoCounter -= 1;
        else potatoCounter = 0;
        if (tomatoCounter > 0) tomatoCounter -= 1;
        else tomatoCounter = 0;
        berryCounter += 1;
    }
}
