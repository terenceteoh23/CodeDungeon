using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public GameObject playerUnit;
    public GameObject playerUnitField;

    public Player player;

    void Start()
    {
        if (player.changedScene)
        {
            Vector3 pos = new(player.lastCordX, player.lastCordY, 0);

            playerUnitField.transform.position = pos;

            player.changedScene = false;
        }


    }
}
