using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DetectiveGame.Player;

public class InventoryUIController : MonoBehaviour
{
    public PlayerInventory PlayerInventory;
    public RectTransform GridLayout;

    public List<ItemUIController> ItemDisplays;
    private List<Item> itemsInInventoryUI = new List<Item>();
    public GameObject InventoryUI;
    public GameObject ItemHolderPrefab;

    public void RefreshDisplay()
    {
        //Check if there are items in inventory then update Inventory UI display
        foreach (Item item in PlayerInventory.Items)
        {
            //if(itemsInInventoryUI.Contains(item)) return;

            item.transform.SetParent(GridLayout, false);
            if (item.GetComponent<Image>() == null && item.GetComponent<DragObject>() == null)
            {
                item.gameObject.AddComponent<Image>().sprite = item.Icon;
                item.gameObject.AddComponent<ItemDrag>();
            }

            item.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
            //itemsInInventoryUI.Add(item);

            //ItemUIController uiController = item.GetComponent<ItemUIController>();
            //uiController.ItemRef = item;
        }
    }

}
