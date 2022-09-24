using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Colliable
{
    public string[] sceneNames; 
    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player(field)")
        {

            GameManager.instance.SaveState();
            GameManager.instance.PlayerIsStarting(true);

            //Teleport the player
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];

            EnvironmentManager.instance.DestoryObject();
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}
