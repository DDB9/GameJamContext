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

    Inventory inventory;

    /*
    public StaminaHealthBarManager hungerBarScript;
    public float hungerRegain;
    public float tomatoRegain = 15;
    public float berryRegain = 10;
    public float potatoRegain = 20;

    // counters 
    public int berryCount;
    public int tomatoCount;
    public int potatoCount;
    */


    List<Image> inventorySlots = new List<Image>();

    // Start is called before the first frame update
    void Awake()
    {
        grid = FindObjectOfType<GridManager>();
        inventory = FindObjectOfType<Inventory>();
    }

    private void Start()
    {
        inventorySlots.Add(GameObject.Find("INV_slot 1").GetComponent<Image>());
        inventorySlots.Add(GameObject.Find("INV_slot 2").GetComponent<Image>());
        inventorySlots.Add(GameObject.Find("INV_slot 3").GetComponent<Image>());
        inventorySlots.Add(GameObject.Find("INV_slot 4").GetComponent<Image>());
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
                if (hitInfo.transform.tag == "Interactable"     // This shhould probably go in playercontrols.
                    && hitInfo.transform.tag != "Pickupable"
                    && hitInfo.transform.tag != "Occupied")
                {
                    Debug.DrawRay(GameObject.Find("Main Camera").transform.position, Vector3.forward);
                    PlaceCubeNear(hitInfo.point);
                }
                else return;
            }
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
                    Instantiate(blueberry, finalPosition, Quaternion.identity);
                    firstInventorySlot.GetComponent<Image>().enabled = false;
                    firstInventorySlot.GetComponent<Image>().sprite = null;
                    inventory.RemoveItem(GameObject.Find("Dummy Blueberry").GetComponent<IInventoryItem>());
            }

            else if (firstInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                    Instantiate(potato, finalPosition, Quaternion.identity);
                    firstInventorySlot.GetComponent<Image>().enabled = false;
                    firstInventorySlot.GetComponent<Image>().sprite = null;
                    inventory.RemoveItem(GameObject.Find("Dummy Potato").GetComponent<IInventoryItem>());
            }           

            else if (firstInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                Instantiate(tomato, finalPosition, Quaternion.Euler(new Vector3(0f, 90f, 0f)));
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                inventory.RemoveItem(GameObject.Find("Dummy Tomato").GetComponent<IInventoryItem>());
            }

        }

        if (CharacterControls.currentSelected == 1)
        {
            if (secondInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {
                    Instantiate(blueberry, finalPosition, Quaternion.identity);
                    secondInventorySlot.GetComponent<Image>().enabled = false;
                    secondInventorySlot.GetComponent<Image>().sprite = null;
                    inventory.RemoveItem(GameObject.Find("Dummy Blueberry").GetComponent<IInventoryItem>());
            }

            else if (secondInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                Instantiate(potato, finalPosition, Quaternion.identity);
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                inventory.RemoveItem(GameObject.Find("Dummy Potato").GetComponent<IInventoryItem>());
            }

            else if (secondInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                Instantiate(tomato, finalPosition, Quaternion.Euler(new Vector3(0f, 90f, 0f)));
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                inventory.RemoveItem(GameObject.Find("Dummy Tomato").GetComponent<IInventoryItem>());
            }
        }

        if (CharacterControls.currentSelected == 2)
        {
            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {
                    Instantiate(blueberry, finalPosition, Quaternion.identity);
                    thirdInventorySlot.GetComponent<Image>().enabled = false;
                    thirdInventorySlot.GetComponent<Image>().sprite = null;
                    inventory.RemoveItem(GameObject.Find("Dummy Blueberry").GetComponent<IInventoryItem>());
            }

            else if (thirdInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                Instantiate(potato, finalPosition, Quaternion.identity);
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                inventory.RemoveItem(GameObject.Find("Dummy Potato").GetComponent<IInventoryItem>());
            }

            else if (thirdInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                Instantiate(tomato, finalPosition, Quaternion.Euler(new Vector3(0f, 90f, 0f)));
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                inventory.RemoveItem(GameObject.Find("Dummy Tomato").GetComponent<IInventoryItem>());
            }
        }

        if (CharacterControls.currentSelected == 3)
        {
            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {
                    Instantiate(blueberry, finalPosition, Quaternion.identity);
                    fourthInventorySlot.GetComponent<Image>().enabled = false;
                    fourthInventorySlot.GetComponent<Image>().sprite = null;
                    inventory.RemoveItem(GameObject.Find("Dummy Blueberry").GetComponent<IInventoryItem>());
            }

            else if (fourthInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                Instantiate(potato, finalPosition, Quaternion.identity);
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                inventory.RemoveItem(GameObject.Find("Dummy Potato").GetComponent<IInventoryItem>());
            }

            else if (fourthInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                Instantiate(tomato, finalPosition, Quaternion.Euler(new Vector3(0f, 90f, 0f)));
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                inventory.RemoveItem(GameObject.Find("Dummy Tomato").GetComponent<IInventoryItem>());
            }
        }
    }

}
