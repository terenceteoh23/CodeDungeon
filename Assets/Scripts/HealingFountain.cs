using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingFountain : Collectable
{
    public GameObject fountain;
    public int hp;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            ChangeSprite();
            GameManager.instance.ShowText("Recover " + hp + " HP", 25, Color.white, transform.position, Vector3.up * 50, 2.0f);
            GameManager.instance.ChangePlayerStats(0, 0, 0, hp, 0);
        }
    }
    public void SetCollected(bool b)
    {
        collected = b;
    }

    public void ChangeSprite()
    {
        Destroy(fountain);
    }

}
