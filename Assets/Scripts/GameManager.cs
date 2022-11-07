using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            //First run, set the instance
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (instance != this)
        {
            //Instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if (player.isDead)
        {
            player.resetPlayer();
        }

        LoadState();
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable = new List<int>() { 0, 15, 45, 90, 150, 220, 300, 410, 650, 850};

    //References
    public GameObject playerUnit;
    public Player player;
    public int enemyId;
    public Inventory inventory;

    //Managers
    public EnvironmentManager environmentManager;
    public FloatingTextManager floatingTextManager;
    public InventoryManager inventoryManager;
    public MenuManager menuManager;
    public ItemManager itemManager;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public void ChangePlayerStats(int level, int damage, int maxhp, int currenthp, int knowledge)
    {
        player.ChangeStats(level, damage, maxhp, currenthp, knowledge);
    }

    //set the exp gained
    public void SetEXP(int exp)
    {
        player.SetEXP(exp);
        int current = player.GetEXP();
        if (current > xpTable[player.level])
        {
            LevelUp();
        }
    }

    public void SetEXP()
    {
        int current = player.GetEXP();
        if(player.level < 10)
        {
            if (current >= xpTable[player.level])
            {
                LevelUp();
            }
        }
    }

    public void LevelUp()
    {
        player.LevelUp(xpTable);
        SetEXP();
    }

    public void PlayerIsStarting(bool b)
    {
        player.isStarting = b;
    }

    //Changing Scene
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //Item management
    public void ObtainItem(ItemData item)
    {
        inventory.Add(item);
    }
    public void UseItem(InventorySlot slot)
    {
        ItemData item = slot.itemData;
        itemManager.UseItem(item);
        inventory.Remove(item);
        inventoryManager.DrawInventory(inventory.GetInventory());
        menuManager.SetPlayerInfo(player, xpTable);
    }


    //Show and Hide Menu
    public void ShowMenu()
    {
        menuManager.ShowMenu();
        inventoryManager.DrawInventory(inventory.GetInventory());
        menuManager.SetPlayerInfo(player , xpTable);
    }
    public void HideMenu()
    {
        menuManager.HideMenu();
    }

    //Destorying a gameobject
    public void DestoryObject()
    {
        Destroy(gameObject);
    }

    //Saving and Loading
    public void SaveState()
    {
        PlayerPrefs.SetString("Player", player.SaveData());
        inventory.SaveInventory();
    }

    public void LoadState()
    {
        if (PlayerPrefs.HasKey("Player"))
        {
            player.LoadData(PlayerPrefs.GetString("Player"));
        }

        inventory.LoadInventory();
    }
}
