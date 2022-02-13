using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Item/Item Data", order = 0)]
public class ItemData : ScriptableGameObject
{
    public string Name;
    public string ItemId;
    public string ItemDescription;
    public Sprite Icon;
    public int ItemQuantity;
    public int MaxItemQuantity;
}
