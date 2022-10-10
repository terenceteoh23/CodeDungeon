using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Colliable
{
    public string battleScene;
    public bool defeated;
    public GameObject Enemy;

    protected override void OnCollide(Collider2D coll)
    {
        if (!defeated)
        {
            Defeated();

            GameManager.instance.SaveState();
            EnvironmentManager.instance.SavePlayerLocation();
            EnvironmentManager.instance.SaveState();
            //Teleport the player
            GameManager.instance.ChangeScene(battleScene);
        }
    }

    public void Defeated()
    {
        defeated = true;
        Destroy(Enemy);

    }
}
