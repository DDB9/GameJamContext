using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class CharacterControls : MonoBehaviour
{
    public static CharacterControls instance = null;

    public float speed = 7.0f;
    public float gravity = 20.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 1.0f;
    public Inventory inventory;
    public GameObject _inventory;
    public GameObject _booklet;
    public bool inventoryActive;

    public Camera camera;

    public static int currentSelected = 0;

    public Image[] inventorySlots = new Image[4];

    private bool grounded = false;
    private float sprintSpeed;
    private float walkSpeed;

    private Image blueberryInfo, potatoInfo, tomatoInfo;

    void Awake()
    {
        if (_inventory.activeInHierarchy) _inventory.SetActive(false);  // Disable inventory on play (if active).
        if (_booklet.activeInHierarchy) _booklet.SetActive(false);      // Do the same for the booklet.

        sprintSpeed = speed * 1.75f;
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
        // Open inventory.
        if (Input.GetKeyDown("e"))
        {
            if (!_inventory.activeInHierarchy)
            {
                _inventory.SetActive(true);
                inventoryActive = true;
            }
            else if (_inventory.activeInHierarchy)
            {
                _inventory.SetActive(false);
                inventoryActive = false;
            }
        }

        // Open booklet.
        if (Input.GetKeyDown("q"))
        {
            if (!_booklet.activeInHierarchy)
            {
                _booklet.SetActive(true);
            }
            else if (_booklet.activeInHierarchy)
            {
                _booklet.SetActive(false);
            }
        }

        // Inventory Selection
        if (_inventory.activeInHierarchy)
        {
            // Scrollwheel input.
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
            // Keyboard input.
            if (Input.GetKeyDown(KeyCode.Alpha1)) currentSelected = 0;
            if (Input.GetKeyDown(KeyCode.Alpha2)) currentSelected = 1;
            if (Input.GetKeyDown(KeyCode.Alpha3)) currentSelected = 2;
            if (Input.GetKeyDown(KeyCode.Alpha4)) currentSelected = 3;

            // Setting the slots active and inactive.
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

        // When player presses his left mouse button...
        if (Input.GetMouseButtonDown(0)) 
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            // ... And he is looking at...
            if (Physics.Raycast(ray, out hitInfo))
            {
                // ... Forest gate, then load Forest scene.
                if (hitInfo.transform.CompareTag("Forest Gate"))
                {
                    SceneManager.LoadScene("Forest");
                }
                // ... Lake gate, then load Lake scene.
                else if (hitInfo.transform.CompareTag("Lake Gate"))
                {
                    SceneManager.LoadScene("Lake");
                }
                // ... Farm gate, then load Farm scene.
                else if (hitInfo.transform.CompareTag("Farm Gate"))
                {
                    SceneManager.LoadScene("Farm");
                }
            }

            var firstInventorySlot = inventorySlots[0].transform.GetChild(0);
            var secondInventorySlot = inventorySlots[1].transform.GetChild(0);
            var thirdInventorySlot = inventorySlots[2].transform.GetChild(0);
            var fourthInventorySlot = inventorySlots[3].transform.GetChild(0);

            if (currentSelected == 0 && firstInventorySlot.GetComponent<Image>().sprite.name == "spear") 
            {
                if (hitInfo.transform.CompareTag("Fish")) 
                {
                    Destroy(hitInfo.transform.GetComponent<GameObject>());
                }
            }
            if (currentSelected == 1 && secondInventorySlot.GetComponent<Image>().sprite.name == "spear") 
            {
                if (hitInfo.transform.CompareTag("Fish")) 
                {
                    Destroy(hitInfo.transform.GetComponent<GameObject>());
                }
            }
            if (currentSelected == 2 && thirdInventorySlot.GetComponent<Image>().sprite.name == "spear") 
            {
                if (hitInfo.transform.CompareTag("Fish")) 
                {
                    Destroy(hitInfo.transform.GetComponent<GameObject>());
                }
            }
            if (currentSelected == 3 && fourthInventorySlot.GetComponent<Image>().sprite.name == "spear") 
            {
                if (hitInfo.transform.CompareTag("Fish")) 
                {
                    Destroy(hitInfo.transform.GetComponent<GameObject>());
                }
            }
        }
        
        RaycastHit hit;
        Debug.DrawRay(transform.position, camera.transform.forward, Color.green);
        // Constantly checks if the player is looking at a pickupable.
        if (Physics.Raycast(transform.position, camera.transform.TransformDirection(Vector3.forward), out hit, 3f)) 
        {
            if (hit.transform.name == "Tomato") 
            {
                tomatoInfo = GameObject.Find("TMTInfoPanel").GetComponent<Image>();
                tomatoInfo.enabled = true;  // Enabled the info panel.
            }
            else if (tomatoInfo != null)
            {
                tomatoInfo.enabled = false;     // Otherwise the panels are disabled to prevent littering.
            }
            if (hit.transform.name == "Potato") 
            {
                potatoInfo = GameObject.Find("PTTInfoPanel").GetComponent<Image>();
                potatoInfo.enabled = true;  // Enabled the info panel.
            }
            else if (potatoInfo != null)
            {
                potatoInfo.enabled = false;
            }
            if (hit.transform.name == "Blueberry") 
            {
                blueberryInfo = GameObject.Find("BBInfoPanel").GetComponent<Image>();
                blueberryInfo.enabled = true;   // Enabled the info panel.
            }
            else if (blueberryInfo != null) 
            {
                blueberryInfo.enabled = false;
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

    private void OnCollisionEnter(Collision hit) // aAA don't comment this out it really scared me when stuff stopped working...!
    {
        if (hit.collider.tag == "Pickupable")
        {
            IInventoryItem item = hit.collider.GetComponent<IInventoryItem>();
            if (item != null)
            {
                inventory.AddItem(item);
            }
        }
    }
    
}