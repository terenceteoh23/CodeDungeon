using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    //public List<InventorySlot> inventorySlots = new List<InventorySlot>(5);

    /*void ResetInventory()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.transform);
        }

        inventorySlots = new List<InventorySlot>(5);

    }*/

    public void DrawInventory(List<ItemData> inventory)
    {
        foreach(Transform childTransform in transform)
        {
            childTransform.gameObject.SetActive(false);
        }

        for (int i = 0; i < inventory.Count; i++)
        {
            Transform childTransform = transform.GetChild(i);
            InventorySlot slot = childTransform.GetComponent<InventorySlot>();
            childTransform.gameObject.SetActive(true);
            slot.DrawSlot(inventory[i]);
        }
    }

    /*void CreateInventorySlot()
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        InventorySlot newSlotComponet = newSlot.GetComponent<InventorySlot>();
        newSlotComponet.ClearSlot();

        inventorySlots.Add(newSlotComponet);
    }*/


}
