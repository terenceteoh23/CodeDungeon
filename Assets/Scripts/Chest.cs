using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    //bool collected
    public Sprite emptyChest;
    public int moneyAmount = 10;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            EnvironmentManager.instance.openedChests.Add(this);
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ChangePlayerStats(0, 6, 3, 0, 0);
        }
    }

    public void setCollected(bool b)
    {
        collected = b;
    }

}
