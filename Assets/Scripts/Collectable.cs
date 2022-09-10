using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Colliable
{
    protected bool collected;

    protected override void OnCollide(Collider2D coll)
    {
        if(coll.name == "Player(field)")
        {
            OnCollect();
        }
    }

    protected virtual void OnCollect()
    {
        collected = true;
    }
}
