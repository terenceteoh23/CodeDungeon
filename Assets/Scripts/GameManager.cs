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

        //SceneManager.sceneLoaded += LoadState;
        LoadState();
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public GameObject playerUnit;
    public Player player;
    public int enemyId;
    
    public EnvironmentManager environmentManager;
    public FloatingTextManager floatingTextManager;
    public Inventory inventory;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public void ChangePlayerStats(int level, int damage, int maxhp, int currenthp, int knowledge)
    {
        player.ChangeStats(level, damage, maxhp, currenthp, knowledge);
    }

    public void PlayerIsStarting(bool b)
    {
        player.isStarting = b;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void DestoryObject()
    {
        Destroy(gameObject);
    }

    public void SaveState()
    {
        PlayerPrefs.SetString("Player", player.SaveData());
    }

    public void LoadState()
    {
        if (PlayerPrefs.HasKey("Player"))
        {
            player.LoadData(PlayerPrefs.GetString("Player"));
        }
    }
}
