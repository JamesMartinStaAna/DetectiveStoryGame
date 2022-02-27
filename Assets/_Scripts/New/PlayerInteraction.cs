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

        public void Interact(Item item)
        {
            if (!playerInventory.IsFull)
            {
                playerInventory.AddItem(item);
                onItemPickup?.Raise();    
            }
        }
    }
}
