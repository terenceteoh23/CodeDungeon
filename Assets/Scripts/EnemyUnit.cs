using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnit : Colliable
{
    public string battleScene;

    protected override void OnCollide(Collider2D coll)
    {
            GameManager.instance.SaveState();
            EnvironmentManager.instance.SavePlayerLocation();
            //Teleport the player
            GameManager.instance.ChangeScene(battleScene);
    }
}
