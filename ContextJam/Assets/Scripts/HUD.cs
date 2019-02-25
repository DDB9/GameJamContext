using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject player;
    public Inventory Inventory;
    public GameObject farmOverlay;
    public GameObject invOverlay;
    public GameObject playerCam;

    // Start is called before the first frame update
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
        Inventory.ItemRemoved += Inventory_ItemRemoved;
    }

    // Item added event.
    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventory");
        foreach(Transform slot in inventoryPanel)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();

            ItemDragHandler itemDragHandler = image.GetComponent<ItemDragHandler>();

            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                itemDragHandler.Item = e.Item;

                break;
            }
        }
    }

    // Item removed event.
    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("Inventory");
        foreach(Transform slot in inventoryPanel)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();
            
            ItemDragHandler itemDragHandler = image.GetComponent<ItemDragHandler>();

            if (itemDragHandler.Item.Equals(e.Item))
            {
                image.enabled = false;
                image.sprite = null;

                itemDragHandler.Item = null;

                break;
            }
        }
    }
}
