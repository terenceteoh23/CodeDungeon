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

        SceneManager.sceneLoaded += LoadState;

        //playerFieldData = playerData;

        /*if (playerFieldData.isStarting == true)
        {
            playerUnitField.transform.position = startingPos.position;
            playerFieldData.isStarting = false;
            Debug.Log("STARTING");
        }
        else
        {
            Vector3 tempPos = playerFieldData.GetLocation();
            playerUnitField.transform.position = tempPos;
            Debug.Log("NOT STARTING");
        }*/
            

        /*//create a clone of the prefab
        if (player.isStarting == true)
        {
            playerUnitField = Instantiate(playerUnit, startingPos);
            player.isStarting = false;
            Debug.Log("STARTING");
        }
        else
        {
            Vector3 tempPos = player.GetLocation();
            playerUnitField = Instantiate(playerUnit, tempPos, new Quaternion(0,0,0,0));
            Debug.Log("NOT STARTING");
        }*/
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public GameObject playerUnit;
    public Player player;
    //public GameObject playerUnitField;

    public EnvironmentManager environmentManager;

    //public Transform startingPos;
    //public bool starting;

    
    //public Player playerFieldData;

    public FloatingTextManager floatingTextManager;

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

    /*public void SavePlayerLocation()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;

        float cordX = playerUnitField.transform.localPosition.x;
        float cordY = playerUnitField.transform.localPosition.y;

        playerData.SaveLocation(sceneName, cordX, cordY);
    }*/

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
