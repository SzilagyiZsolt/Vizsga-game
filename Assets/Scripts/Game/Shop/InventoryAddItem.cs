using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAddItem : MonoBehaviour
{
    public float timer;
    public bool playerInRange;
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;
    public Item itemid;
    private void Start()
    {
        //GameObject inventory = GameObject.FindWithTag("InventoryManager");
        //inventoryManager = inventory.GetComponent<InventoryManager>();
    }
    private void Update()
    {
        timer += Time.deltaTime;
    }
    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")&&timer>1.5&&Input.GetKeyDown(KeyCode.E))
        {
            PickupItem(itemid.id);
            transform.localScale = new Vector3(1,1,1);
            playerInRange = true;
            Destroy(gameObject);
            
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
    
    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if (result)
        {
            Debug.Log("Item added");
        }
        else
        {
            Debug.Log("ITEM NOT ADDED");
        }
    }
}
