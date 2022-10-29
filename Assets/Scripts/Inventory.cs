using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> inventory = new List<ItemData>();

    public void Add(ItemData item) 
    {
        inventory.Add(item);
    }

    public void Remove(ItemData item)
    {
        inventory.Remove(item);
    }
}
