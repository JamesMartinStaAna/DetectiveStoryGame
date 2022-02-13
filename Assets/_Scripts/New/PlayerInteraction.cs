using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DetectiveGame.Player
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private GameEventChannel onItemPickup;
        [SerializeField] private Item itemToPickup;
        [SerializeField] private PlayerInventory playerInventory;
        private PlayerMovement playerMovement;

        private void Awake() {
            playerMovement = GetComponent<PlayerMovement>();
        }

        [ContextMenu("Interact")]
        public void Interact()
        {
            if (itemToPickup != null && !playerInventory.IsFull)
            {
                playerInventory.AddItem(itemToPickup);
                onItemPickup?.Raise();    
            }
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag(DetectiveGameReferences.ITEM))
            {
                itemToPickup = other.GetComponent<Item>();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag(DetectiveGameReferences.ITEM))
            {
                itemToPickup = null;
            }
        }
    }
}
