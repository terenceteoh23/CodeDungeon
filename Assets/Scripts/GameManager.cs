using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private void Awake()
    {
        if(GameManager.instance != null)
        {
            return;
        }

        instance = this;
    
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public GameObject playerUnit;
    public GameObject playerUnitField;

    public Player player;

    public FloatingTextManager floatingTextManager;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    public void ChangePlayerStats(int level, int damage, int maxhp, int currenthp, int knowledge)
    {
        player.ChangeStats(level, damage, maxhp, currenthp, knowledge);
    }

    public void SavePlayerLocation()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;

        float cordX = playerUnitField.transform.localPosition.x;
        float cordY = playerUnitField.transform.localPosition.y;

        player.SaveLocation(sceneName, cordX, cordY);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //save and load state
    public void SaveState()
    {

    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        
    }
}
