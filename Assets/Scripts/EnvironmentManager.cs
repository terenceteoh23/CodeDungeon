using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnvironmentManager : MonoBehaviour
{
    public static EnvironmentManager instance;

    //player references
    //public GameObject playerUnit;
    public GameObject playerUnitField;
    public Player player;
    public List<Chest> Chests;
    //public List<HealingFountain> Fountains;
    public List<EnemyUnit> Enemy;

    //map references
    public Transform startingPos;

    public void Awake()
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

        //playerUnitField = Instantiate(playerUnit);

        if (player.isStarting)
        {
            playerUnitField.transform.position = startingPos.position;
            player.isStarting = false;
        }
        else
        {
            Vector3 tempPos = player.GetLocation();
            playerUnitField.transform.position = tempPos;
        }

        SceneManager.sceneLoaded += LoadState;
    }

    public void SavePlayerLocation()
    {
        Scene scene = SceneManager.GetActiveScene();
        string sceneName = scene.name;

        float cordX = playerUnitField.transform.localPosition.x;
        float cordY = playerUnitField.transform.localPosition.y;

        player.SaveLocation(sceneName, cordX, cordY);
    }

    public void DestoryObject()
    {
        Destroy(gameObject);
    }

    public void SaveState()
    {
        string chestSave = "";
        string enemySave = "";
        //string fountainSave = "";

        foreach(Chest chest in Chests)
        {
            chestSave += chest.collected + "|";
        }

        chestSave += 0;

        foreach (EnemyUnit enemy in Enemy)
        {
            enemySave += enemy.defeated + "|";
        }

        enemySave += 0;

        /*foreach (HealingFountain fountain in Fountains)
        {
            fountainSave += fountain.collected + "|";
        }

        fountainSave += 0;
        */

        PlayerPrefs.SetString("Chest", chestSave);
        PlayerPrefs.SetString("Enemy", enemySave);
        //PlayerPrefs.SetString("Fountain", fountainSave);
        PlayerPrefs.Save();


    }

    public void LoadState(Scene s, LoadSceneMode mode)
    {
        if (PlayerPrefs.HasKey("Chest"))
        {
            string[] data = PlayerPrefs.GetString("Chest").Split("|");
            if(Chests.Count > 0)
            {
                for (int i = 0; i < Chests.Count; i++)
                {
                    if (data[i] == "True")
                    {
                        Chests[i].collected = true;
                        Chests[i].ChangeSprite();
                    }
                    else if (data[i] == "False")
                    {
                        Chests[i].collected = false;
                    }
                    else
                    {
                        Debug.Log("End");
                    }

                }
            }   
        }

        if (PlayerPrefs.HasKey("Enemy"))
        {
            string[] data = PlayerPrefs.GetString("Enemy").Split("|");
            if(Enemy.Count > 0)
            {
                for (int i = 0; i < Enemy.Count; i++)
                {
                    if (data[i] == "True")
                    {
                        Enemy[i].Defeated();
                    }
                    else
                    {
                        Debug.Log("End");
                    }
                }
            }  
        }

        /*if (PlayerPrefs.HasKey("Fountain"))
        {
            string[] data = PlayerPrefs.GetString("Fountain").Split("|");

            if(Fountains.Count > 0)
            {
                for (int i = 0; i < Fountains.Count; i++)
                {
                    if (data[i] == "True")
                    {
                        Fountains[i].collected = true;
                        Fountains[i].ChangeSprite();
                    }
                    else if (data[i] == "False")
                    {
                        Fountains[i].collected = false;
                    }
                    else
                    {
                        Debug.Log("End");
                    }

                }
            }
        }*/
    }

    public void DeleteState()
    {
        PlayerPrefs.DeleteAll();
    }

}
