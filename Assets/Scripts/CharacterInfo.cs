using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterInfo : MonoBehaviour
{
    //character stats
    public string Cname;
    public int level;

    public int damage;

    public int maxHP;
    public int currentHP;
    
    public int Attack()
    {
        return damage;
    }
    
    public bool TakeDamage(int dmg)
    {
        currentHP -= dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal()
    {
        currentHP += 3;
    }
}
