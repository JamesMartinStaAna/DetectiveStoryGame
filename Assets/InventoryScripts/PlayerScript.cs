using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //DEBUG TEST
    public Item ItemToPickup;
    public Inventory Inventory;

    [Header("Warrior's Emblem")]
    public bool IsWarriorsEmblemInventory;

    // Start is called before the first frame update
    void Start()
    {
        IsWarriorsEmblemInventory = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && ItemToPickup != null && Inventory.IsFull == false) 
        {
            Inventory.AddItem(ItemToPickup);

            if (ItemToPickup.ItemId == "0001")
            {
                IsWarriorsEmblemInventory = true;
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Assign pickup object on collision
        if (collision.gameObject.CompareTag("Item"))
        {
            ItemToPickup = collision.gameObject.GetComponent<Item>();
        }
    }

}
