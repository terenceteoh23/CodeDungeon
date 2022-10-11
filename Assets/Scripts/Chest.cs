using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int moneyAmount = 10;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.ChangePlayerStats(0, 6, 3, 0, 0);
        }
    }

    public void SetCollected(bool b)
    {
        collected = b;
    }

    public void ChangeSprite()
    {
        GetComponent<SpriteRenderer>().sprite = emptyChest;
    }

}
