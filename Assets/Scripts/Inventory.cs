using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> inventory = new List<ItemData>(5);
    public List<ItemData> dictionary = new List<ItemData>();

    public void Add(ItemData item) 
    {
        inventory.Add(item);
    }

    public void Remove(ItemData item)
    {
        inventory.Remove(item);
    }

    public List<ItemData> GetInventory()
    {
        return inventory;
    }

    public int GetInventorySize()
    {
        return inventory.Count;
    }

    public void SaveInventory()    
    {
        string InventorySave="";

        foreach (ItemData item in inventory)
        {
            InventorySave += item.id + "|";
            
        }
        PlayerPrefs.SetString("Inventory", InventorySave);
    }

    public void LoadInventory()
    {
        if (PlayerPrefs.HasKey("Inventory"))
        {
            string[] data = PlayerPrefs.GetString("Inventory").Split("|");

            foreach(string id in data)
            {
                switch (id)
                {
                    case "0":
                        Add(dictionary[0]);
                        break;
                    case "1":
                        Add(dictionary[1]);
                        break;
                    case "2":
                        Add(dictionary[2]);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
