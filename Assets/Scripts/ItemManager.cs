using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public Player player;

    public void UseItem(ItemData item)
    {
        switch (item.id)
        {
            case 0:
                player.ChangeStats(0,0,0,100,0);
                break;

            case 1:
                player.ChangeStats(0, 3, 0, 0, 0);
                break;

            case 2:
                GameManager.instance.SetEXP(100);
                break;

            default:
                break;
        }
    }
}
