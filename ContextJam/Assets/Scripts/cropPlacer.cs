using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cropPlacer : MonoBehaviour
{
    private Grid grid;

    public GameObject blueberry;
    public GameObject bucket;

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

        // Checks what item is in the currently selected slot.
        if (CharacterControls.currentSelected == 0)
        {
            if (inventorySlots[0].transform.GetChild(0).GetComponent<Image>().sprite.name == "Blueberry-Sprite")
            {
                Instantiate(blueberry, finalPosition, Quaternion.identity);
                inventorySlots[0].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }

            // Is now bucket for protyping purposes, will become other vegetalbes later.
            if (inventorySlots[0].transform.GetChild(0).GetComponent<Image>().sprite.name == "Bucket")
            {
                Instantiate(bucket, finalPosition, Quaternion.identity);
                inventorySlots[0].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }

        if (CharacterControls.currentSelected == 1)
        {
            if (inventorySlots[1].transform.GetChild(0).GetComponent<Image>().sprite.name == "Blueberry-Sprite")
            {
                Instantiate(blueberry, finalPosition, Quaternion.identity);
                inventorySlots[1].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }

            // Is now bucket for protyping purposes, will become other vegetalbes later.
            if (inventorySlots[1].transform.GetChild(0).GetComponent<Image>().sprite.name == "Bucket")
            {
                Instantiate(bucket, finalPosition, Quaternion.identity);
                inventorySlots[1].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }

        if (CharacterControls.currentSelected == 2)
        {
            if (inventorySlots[2].transform.GetChild(0).GetComponent<Image>().sprite.name == "Blueberry-Sprite")
            {
                Instantiate(blueberry, finalPosition, Quaternion.identity);
                inventorySlots[2].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }

            // Is now bucket for protyping purposes, will become other vegetalbes later.
            if (inventorySlots[2].transform.GetChild(0).GetComponent<Image>().sprite.name == "Bucket")
            {
                Instantiate(bucket, finalPosition, Quaternion.identity);
                inventorySlots[2].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }

        if (CharacterControls.currentSelected == 3)
        {
            if (inventorySlots[3].transform.GetChild(0).GetComponent<Image>().sprite.name == "Blueberry-Sprite")
            {
                Instantiate(blueberry, finalPosition, Quaternion.identity);
                inventorySlots[3].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }

            // Is now bucket for protyping purposes, will become other vegetalbes later.
            if (inventorySlots[3].transform.GetChild(0).GetComponent<Image>().sprite.name == "Bucket")
            {
                Instantiate(bucket, finalPosition, Quaternion.identity);
                inventorySlots[3].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }
    }
}
