using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cropPlacer : MonoBehaviour
{
    private Grid grid;

    public Inventory _inventory;

    public GameObject blueberry;
    public GameObject potato;
    public GameObject tomato;

    public IInventoryItem iBlueberry;

    public Image[] inventorySlots = new Image[4];

    // Start is called before the first frame update
    void Awake()
    {
        grid = FindObjectOfType<Grid>();
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
                if (hitInfo.transform.tag == "Interactable" && hitInfo.transform.tag != "Pickupable")
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
            IInventoryItem item = firstInventorySlot.gameObject.GetComponent<ItemDragHandler>().Item;

            if (firstInventorySlot.GetComponent<Image>().sprite.name == "Blueberry-Sprite")
            {
                Instantiate(blueberry, finalPosition, Quaternion.identity);
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(0);
            }

            // Is now bucket for protyping purposes, will become other vegetalbes later.
            if (firstInventorySlot.GetComponent<Image>().sprite.name == "potato")
            {
                Instantiate(potato, finalPosition, Quaternion.identity);
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(0);
            }
        }

        if (CharacterControls.currentSelected == 1)
        {
            if (secondInventorySlot.GetComponent<Image>().sprite.name == "Blueberry-Sprite")
            {
                Instantiate(blueberry, finalPosition, Quaternion.identity);
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(1);
            }

            // Is now bucket for protyping purposes, will become other vegetalbes later.
            if (secondInventorySlot.GetComponent<Image>().sprite.name == "potato")
            {
                Instantiate(potato, finalPosition, Quaternion.identity);
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(1);
            }
        }

        if (CharacterControls.currentSelected == 2)
        {
            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "Blueberry-Sprite")
            {
                Instantiate(blueberry, finalPosition, Quaternion.identity);
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(2);
            }

            // Is now bucket for protyping purposes, will become other vegetalbes later.
            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "potato")
            {
                Instantiate(potato, finalPosition, Quaternion.identity);
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(2);
            }
        }

        if (CharacterControls.currentSelected == 3)
        {
            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "Blueberry-Sprite")
            {
                Instantiate(blueberry, finalPosition, Quaternion.identity);
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(3);
            }

            // Is now bucket for protyping purposes, will become other vegetalbes later.
            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "potato")
            {
                Instantiate(potato, finalPosition, Quaternion.identity);
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(3);
            }
        }
    }
}
