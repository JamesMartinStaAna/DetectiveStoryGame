using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemUIController : MonoBehaviour
{
    [Header("Item UI Manager")]
    [HideInInspector]public Item ItemRef;
    [HideInInspector]public Image ItemDisplayIcon;
    public TextMeshProUGUI ItemQuantityText;

    // Update is called once per frame
    void Update()
    {

        if (ItemRef == null)
        {
            //If object stack empty delete item UI
            Destroy(gameObject);
            ItemDisplayIcon.overrideSprite = null;
            ItemQuantityText.text = "";
        }
        else
        {
            ItemDisplayIcon.overrideSprite = ItemRef.Icon;
            if (ItemRef.ItemQuantity == 1)
            {
                ItemQuantityText.text = "";
            }
            else
            {
                ItemQuantityText.text = ItemRef.ItemQuantity.ToString();
            }
            
        }
       
     
    }

    void OnDisable()
    {
        //Deletes extra dublicate on Inventory UI disable
        Destroy(gameObject);
    }
}
