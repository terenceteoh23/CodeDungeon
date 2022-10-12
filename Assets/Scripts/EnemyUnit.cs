using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Colliable
{
    public string battleScene;
    public bool defeated;
    public int enemyId;
    public GameObject enemy;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player(field)")
        {
            if (!defeated)
            {
                Defeated();

                EnvironmentManager.instance.SavePlayerLocation();
                EnvironmentManager.instance.SaveState();
                GameManager.instance.enemyId = enemyId;

                //Teleport the player
                GameManager.instance.ChangeScene(battleScene);
            }
        }   
    }

    public void Defeated()
    {
        defeated = true;
        Destroy(enemy);

    }
}
