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

    // things for eating 
    public StaminaHealthBarManager hungerBarScript;
    public float hungerRegain;
    public float tomatoRegain = 15;
    public float berryRegain = 10;
    public float potatoRegain = 20;
    // counters 
    public int berryCount;
    public int tomatoCount;
    public int potatoCount;

    

    void Awake()
    {
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

        //Eating
        if (Input.GetMouseButtonDown(1))
        {
            EatFood();
        }

        potatoRegain = 20 - potatoCount;
        berryRegain = 10 - berryCount;
        tomatoRegain = 15 - tomatoCount;

        // Keyboard input.
        if (Input.GetKeyDown(KeyCode.Alpha1)) currentSelected = 0;
        if (Input.GetKeyDown(KeyCode.Alpha2)) currentSelected = 1;
        if (Input.GetKeyDown(KeyCode.Alpha3)) currentSelected = 2;
        if (Input.GetKeyDown(KeyCode.Alpha4)) currentSelected = 3;

        // Setting the slots active and inactive.
        if (currentSelected == 0) inventorySlots[0].color = new Color32(0, 111, 255, 243);
        else inventorySlots[0].color = Color.white;
        if (currentSelected == 1) inventorySlots[1].color = new Color32(0, 111, 255, 243);
        else inventorySlots[1].color = Color.white;
        if (currentSelected == 2) inventorySlots[2].color = new Color32(0, 111, 255, 243);
        else inventorySlots[2].color = Color.white;
        if (currentSelected == 3) inventorySlots[3].color = new Color32(0, 111, 255, 243);
        else inventorySlots[3].color = Color.white;

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
                if (hitInfo.transform.CompareTag("Lake Gate"))
                {
                    SceneManager.LoadScene("Lake");
                }
                // ... Farm gate, then load Farm scene.
                if (hitInfo.transform.CompareTag("Farm Gate"))
                {
                    SceneManager.LoadScene("FarmReal");
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
                BerryCounter();
                hungerBarScript.hunger += berryRegain;
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(0);
            }

            if (firstInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                PotatoCounter();
                hungerBarScript.hunger += potatoRegain;
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(0);
            }

            if (firstInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                TomatoCounter();
                hungerBarScript.hunger += tomatoRegain;
                firstInventorySlot.GetComponent<Image>().enabled = false;
                firstInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(0);
            }

        }
        if (CharacterControls.currentSelected == 1)
        {
            if (secondInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {
                BerryCounter();
                hungerBarScript.hunger += berryRegain;
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(1);
            }

            if (secondInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                PotatoCounter();
                hungerBarScript.hunger += potatoRegain;
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(1);
            }

            if (secondInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                TomatoCounter();
                hungerBarScript.hunger += tomatoRegain;
                secondInventorySlot.GetComponent<Image>().enabled = false;
                secondInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(1);
            }

        }
        if (CharacterControls.currentSelected == 2)
        {
            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {
                BerryCounter();
                hungerBarScript.hunger += berryRegain;
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(2);
            }

            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                PotatoCounter();
                hungerBarScript.hunger += potatoRegain;
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(2);
            }

            if (thirdInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                TomatoCounter();
                hungerBarScript.hunger += tomatoRegain;
                thirdInventorySlot.GetComponent<Image>().enabled = false;
                thirdInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(2);
            }

        }
        if (CharacterControls.currentSelected == 3)
        {
            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "blueberry-sprite")
            {
                BerryCounter();
                hungerBarScript.hunger += berryRegain;
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(3);
            }

            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "potato-sprite")
            {
                PotatoCounter();
                hungerBarScript.hunger += potatoRegain;
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(3);
            }

            if (fourthInventorySlot.GetComponent<Image>().sprite.name == "tomato-sprite")
            {
                TomatoCounter();
                hungerBarScript.hunger += tomatoRegain;
                fourthInventorySlot.GetComponent<Image>().enabled = false;
                fourthInventorySlot.GetComponent<Image>().sprite = null;
                Inventory.mItems.RemoveAt(3);
            }

        }

    }


    void BerryCounter()
    {
        berryCount += 2;
        if (tomatoCount > 0) tomatoCount -= 1;
        if (potatoCount > 0) potatoCount -= 1;
    }
    void TomatoCounter()
    {
        tomatoCount += 2;
        if (berryCount > 0) berryCount -= 1;
        if (potatoCount > 0) potatoCount -= 1;
    }
    void PotatoCounter()
    {
        potatoCount += 2;
        if (tomatoCount > 0) tomatoCount -= 1;
        if (berryCount > 0) berryCount -= 1;
    }


}