using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject slotPrefab;
    public List<InventorySlot> inventorySlots = new List<InventorySlot>(5);

    void ResetInventory()
    {
        foreach(Transform childTransform in transform)
        {
            Destroy(childTransform.transform);
        }

        inventorySlots = new List<InventorySlot>(5);

    }

    public void DrawInventory(List<ItemData> inventory)
    {
        //ResetInventory();

        /*for(int i = 0; i < inventorySlots.Capacity; i++)
        {
            CreateInventorySlot();
        }*/


        for (int i = 0; i < inventory.Count; i++)
        {
            Transform childTransform = transform.GetChild(i);
            InventorySlot slot = childTransform.GetComponent<InventorySlot>();
            slot.DrawSlot(inventory[i]);
        }

        /*for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].DrawSlot(inventory[i]);
        }*/
    }

    void CreateInventorySlot()
    {
        GameObject newSlot = Instantiate(slotPrefab);
        newSlot.transform.SetParent(transform, false);

        InventorySlot newSlotComponet = newSlot.GetComponent<InventorySlot>();
        newSlotComponet.ClearSlot();

        inventorySlots.Add(newSlotComponet);
    }


}
