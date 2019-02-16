using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cropPlacer : MonoBehaviour
{
    private Grid grid;

    public GameObject blueberry;

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
                if (hitInfo.transform.tag == "Interactable")
                {
                    PlaceCubeNear(hitInfo.point);
                }
                else return;
            }
        }
    }

    void PlaceCubeNear(Vector3 clickPoint)
    {
        var finalPosition = grid.GetNearestPointOnGrid(clickPoint);
        Debug.Log("Get current selected item, place on grid");
        Instantiate(blueberry, finalPosition, Quaternion.identity);
    }
}
