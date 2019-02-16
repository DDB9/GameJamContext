using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class CharacterControls : MonoBehaviour {

    public GameObject playerCam;
    public float speed = 7.0f;
    public float gravity = 20.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 1.0f;
    public Inventory inventory;
    public GameObject _inventory;
    public bool inventoryActive;
    public GameObject farmOverlay;
    public int currentSelected = 0;

    public Image[] inventorySlots = new Image[4];

    private bool grounded = false;
    private float sprintSpeed;
    private float walkSpeed;

    void Awake()
    {
        if (_inventory.activeInHierarchy) _inventory.SetActive(false);  // Disable inventory on play.

        sprintSpeed = speed * 1.50f;
        GetComponent<Rigidbody>().freezeRotation = true;
        GetComponent<Rigidbody>().useGravity = false;
        walkSpeed = speed;

        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;
           
            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
            velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);

            // Jump
            if (canJump && Input.GetButton("Jump"))
            {
                GetComponent<Rigidbody>().velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
            }
        }

        // We apply gravity manually for more tuning control
        GetComponent<Rigidbody>().AddForce(new Vector3(0, -gravity * GetComponent<Rigidbody>().mass, 0));

        grounded = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (!_inventory.activeInHierarchy)
            {
                _inventory.SetActive(true);
                playerCam.GetComponent<cameraController>().enabled = false;

                Cursor.lockState = CursorLockMode.None;

                inventoryActive = true;
            }
            else if (_inventory.activeInHierarchy)
            {
                _inventory.SetActive(false);
                playerCam.GetComponent<cameraController>().enabled = true;

                Cursor.lockState = CursorLockMode.Locked;

                inventoryActive = false;
            }
        }

        // Inventory Selection
        if (_inventory.activeInHierarchy)
        {
            float d = Input.GetAxis("Mouse ScrollWheel");
            if (d > 0f)
            {
                if (currentSelected <= inventorySlots.Length) currentSelected++;
                if (currentSelected >= inventorySlots.Length) currentSelected = 0;
            }
            if (d < 0f)
            {
                if (currentSelected <= inventorySlots.Length) currentSelected--;
                if (currentSelected < 0) currentSelected = 3;
            }

            if (currentSelected == 0) inventorySlots[0].enabled = false;
            else inventorySlots[0].enabled = true;
            if (currentSelected == 1) inventorySlots[1].enabled = false;
            else inventorySlots[1].enabled = true;
            if (currentSelected == 2) inventorySlots[2].enabled = false;
            else inventorySlots[2].enabled = true;
            if (currentSelected == 3) inventorySlots[3].enabled = false;
            else inventorySlots[3].enabled = true;
        }

        // Sprint if the shift-key has been pressed.
        if (Input.GetKey(KeyCode.LeftShift)) speed = sprintSpeed;
        else speed = walkSpeed;

        // Activate Farm HUD.
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Interactable")
                {
                    farmOverlay.SetActive(true);
                    playerCam.GetComponent<cameraController>().enabled = false;

                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    private void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.tag == "Pickupable")
        {
            IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
            if (item != null)
            {
                inventory.AddItem(item);
            }
        }
        
        //if (hit.collider.name == "blueberries")
        //{
        //    GameObject.Find("Slider").GetComponent<Slider>().value += 30;
        //}
    }
}