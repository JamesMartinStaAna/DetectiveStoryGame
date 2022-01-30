using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Details")]
    public string Name;
    public string ItemId;
    public Sprite Icon;
    public int ItemQuantity;
    public int MaxItemQuantity;
    public bool IsUsable;
    public bool IsFullStack;
    public bool IsUsed;
    public Inventory playerInventory;
    [HideInInspector] public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        IsUsed = false;
        player = GameObject.FindWithTag("Player");
        playerInventory = player.GetComponent<Inventory>();
    } 

    // Update is called once per frame
    void Update()
    {
        //Check if this object as no Quantity then delete from inventory
        ItemUsedUp();

    }

    public void Use()
    {
        if (IsUsable)
        {
            IsUsed = true;
            //Activate other script for health, mana etc.
            Debug.Log("Using item! " + Name);
            //Update ItemQuantity in inventory
            ItemQuantity -= 1;
            
        }
    }

    public void ItemUsedUp()
    {
        if (ItemQuantity <= 0)
        {
            Destroy(this.gameObject);
            playerInventory.itemsInSlots -= 1;

        }
    }

    private void OnDestroy()
    {
        //Remove Object from List
        if (playerInventory.Items != null)
        {
            playerInventory.Items.Remove(this);
        }
    }
}
