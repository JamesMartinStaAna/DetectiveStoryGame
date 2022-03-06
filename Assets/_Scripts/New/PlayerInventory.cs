using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DetectiveGame.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        public List<Item> Items = new List<Item>();

        [Header("Inventory Management")]
        public bool IsFull;
        public int NumberOfSlots;
        public int itemsInSlots = 0;

        //Enable if you want to stack items;
        [SerializeField] private bool StackItems;

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
            itemToAdd.transform.parent = this.transform;

            // Strip down Item's Components except for Item Script and Transform
            foreach (Component c in itemToAdd.GetComponents<Component>())
            {
                if (!(c is Item || c is Transform || c is BoxCollider2D || c is GameEventListener || c is ItemReceiver || c is Rigidbody2D))
                {
                    Destroy(c);
                }
            }

            itemToAdd.GetComponent<BoxCollider2D>().size = new Vector2(100, 100);

            foreach(Transform child in itemToAdd.transform)
            {
                child.gameObject.SetActive(true);
                child.GetComponent<BoxCollider2D>().size = new Vector2(100, 100);
                child.GetComponent<ItemReceiver>().enabled = true;
            }
            Items.Add(itemToAdd);
        }

    }
}
