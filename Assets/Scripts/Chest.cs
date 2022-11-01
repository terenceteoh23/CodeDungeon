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
            if(!(GameManager.instance.inventory.GetInventorySize() >= 5))
            {
                collected = true;
                GetComponent<SpriteRenderer>().sprite = emptyChest;
                GameManager.instance.ObtainItem(item);
                GameManager.instance.ShowText("+" + item.itemName, 25, Color.white, transform.position, Vector3.up * 50, 2.0f);
            }  
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
