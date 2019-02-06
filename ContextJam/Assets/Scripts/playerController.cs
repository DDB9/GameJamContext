using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    public static playerController instance = null;

    public static int playerLives = 5;
    public float walkSpeed = 20f;
    public float sprintSpeed;
    public Inventory inventory;

    [SerializeField]
    private float speed = 20;

    // Use this for initialization
    void Start()
    {
        sprintSpeed = walkSpeed * 1.50f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // PLAYER MOVEMENT
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);

        // Makes the cursor re-appear for menu purposes.
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;

        // If left-shift is pressed, player runs. Else, it walks.
        if (Input.GetKey(KeyCode.LeftShift)) speed = sprintSpeed;
        else speed = walkSpeed;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
        if (item != null)
        {
            inventory.AddItem(item);
        }
    }
}
