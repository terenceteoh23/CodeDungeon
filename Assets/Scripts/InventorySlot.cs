using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image itemIcon;
    public Text itemName;

    public void ClearSlot()
    {
        itemIcon.enabled = false;
        itemName.enabled = false;
    }
    
    public void DrawSlot(ItemData item)
    {
        itemIcon.enabled = true;
        itemName.enabled = true;

        itemIcon.sprite = item.icon;
        itemName.text = item.displayName;
    }
}
