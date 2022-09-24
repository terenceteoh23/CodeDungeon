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

        //cameraMotor.lookAT = playerUnit.transform;

        /*if (player.changedScene)
        {
            Vector3 pos = new(player.lastCordX, player.lastCordY, 0);

            playerUnitField.transform.position = pos;

            player.changedScene = false;
        }*/


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

}
