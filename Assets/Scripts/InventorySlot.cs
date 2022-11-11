using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemData itemData;
    public Image itemIcon;
    public Text itemName;
    public int slotNumber;

    public void ClearSlot()
    {
        itemIcon.enabled = false;
        itemName.enabled = false;
    }
    
    public void DrawSlot(ItemData item)
    {
        itemIcon.enabled = true;
        itemName.enabled = true;

        itemData = item;
        itemIcon.sprite = item.icon;
        itemName.text = item.itemName;
        
    }
}
