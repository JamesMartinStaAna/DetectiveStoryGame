using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DetectiveGame.Player;

public class Item : MonoBehaviour
{
    public ItemData ItemData;

    [HideInInspector]public string Name;
    [HideInInspector]public string ItemId;
    [HideInInspector]public string ItemDescription;
    [HideInInspector]public Sprite Icon;
    [HideInInspector]public int ItemQuantity;
    [HideInInspector]public int MaxItemQuantity;

    
    private PlayerInventory playerInventory;
    private GameObject player;
    [SerializeField] private GameEventChannel itemUseEvent;

    public List<ItemReceiver> itemReceivers = new List<ItemReceiver>();

    public delegate void DragReleaseEvent(Item item);
    public DragReleaseEvent dragReleaseEvent;

    private void Awake() {
        ConstructItem(ItemData);
    }

    private void ConstructItem(ItemData data)
    {
        this.Name= ItemData.Name;
        this.ItemId = ItemData.ItemId;
        this.ItemDescription = ItemData.ItemDescription;
        this.Icon = ItemData.Icon;
        this.ItemQuantity = ItemData.ItemQuantity;
        this.MaxItemQuantity = ItemData.MaxItemQuantity;
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Use()
    {
        //Activate other script for health, mana etc.
        Debug.Log("Using item! " + Name);
        //Update ItemQuantity in inventory
        playerInventory.Items.Remove(this);
        itemUseEvent?.Raise();
        Destroy(this.gameObject);
    }

    public void ToggleItemReceivers(bool value)
    {
        foreach(ItemReceiver itemReceiver in itemReceivers)
        {
            itemReceiver.gameObject.SetActive(value);
        }
    }

    public void ItemUsedUp()
    {
        if (ItemData.ItemQuantity <= 0)
        {
            Destroy(this.gameObject);
            playerInventory.itemsInSlots -= 1;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(DetectiveGameReferences.ITEM_RECEIVER))
        {
            ItemReceiver receiverHovered = other.GetComponent<ItemReceiver>();
            if (receiverHovered.keyID.Equals(ItemId))
            {
                dragReleaseEvent = receiverHovered.ReceiveItem;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(DetectiveGameReferences.ITEM_RECEIVER))
        {
            ItemReceiver receiverHovered = other.GetComponent<ItemReceiver>();
            
            if (receiverHovered.keyID.Equals(ItemId))
            {
                dragReleaseEvent = null;
            }
        }
    }

    private void OnDestroy()
    {
        //Remove Object from List
        if (playerInventory.Items.Contains(this))
        {
            playerInventory.Items.Remove(this);
        }
    }
}
