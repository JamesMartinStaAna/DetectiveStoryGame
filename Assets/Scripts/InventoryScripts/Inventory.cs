using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public List<Item> Items { get; private set; }

    [Header("Inventory Management")]
    public bool IsFull;
    public int NumberOfSlots;
    public int itemsInSlots = 0;

    // Start is called before the first frame update
    void Start()
    {
        Items = new List<Item>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if slots are full
        if (itemsInSlots >= NumberOfSlots)
        {
            IsFull = true;
        }
        else
        {
            IsFull = false;
        }

    }

    public void AddItem(Item itemToAdd)
    {
        foreach (Item currentItem in Items)
        {
            // Check if inventory has similiar items then add quantity
            if (currentItem.ItemId == itemToAdd.ItemId && currentItem.ItemQuantity < currentItem.MaxItemQuantity)
            {
                currentItem.ItemQuantity += itemToAdd.ItemQuantity;
                Destroy(itemToAdd.gameObject);
                return;
            }
        }

        // If item is not yet in inventory add item  
        Item duplicate = Instantiate(itemToAdd);
        itemsInSlots += 1;
        Destroy(itemToAdd.gameObject);

        duplicate.transform.parent = this.transform;

        // Strip down Item's Components except for Item Script and Transform
        foreach(Component c in duplicate.GetComponents<Component>())
        {
            if (! (c is Item || c is Transform))
            {
                Destroy(c);
            }
        }
        Items.Add(duplicate);
        
    }


}
