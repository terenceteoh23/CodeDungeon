using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int damage;
    public int maxhp;
    public int hp;
    public ItemData item;

    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.inventory.Add(item);
            GameManager.instance.ShowText("+" + damage + " Damage\n+" + maxhp + " Max HP", 25, Color.white, transform.position, Vector3.up * 50, 2.0f);
            GameManager.instance.ChangePlayerStats(0, damage, maxhp, hp, 0);
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
