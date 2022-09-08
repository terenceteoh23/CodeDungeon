using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Colliable
{
    public string battleScene;

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.name == "Player")
        {

            GameManager.instance.SaveState();

            //Teleport the player
            UnityEngine.SceneManagement.SceneManager.LoadScene(battleScene);
        }
    }
}
