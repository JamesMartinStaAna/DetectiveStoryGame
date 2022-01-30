using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIController : MonoBehaviour
{
    public Inventory PlayerInventory;
    public RectTransform GridLayout;

    public List<ItemUIController> ItemDisplays;
    public GameObject InventoryUI;
    public GameObject ItemHolderPrefab;

    //Refresh when Inventory UI is enabled
    void OnEnable()
    {
        RefreshDisplay();
    }

    public void RefreshDisplay()
    {
        //Check if there are items in inventory then update Inventory UI display
        foreach (Item item in PlayerInventory.Items)
        {
          
            GameObject itemUI = Instantiate(ItemHolderPrefab);
            itemUI.transform.SetParent(GridLayout, false);

            ItemUIController uiController = itemUI.GetComponent<ItemUIController>();
            uiController.ItemRef = item;
    

        }
    }

}
