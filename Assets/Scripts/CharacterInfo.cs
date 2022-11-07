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
    public int exp;
    
    public int Attack()
    {
        return damage;
    }
    
    public bool TakeDamage(int dmg)
    {
        if(dmg > currentHP)
        {
            currentHP = 0;
        }
        else
        {
            currentHP -= dmg;
        }
        
        if (currentHP <= 0)
            return true;
        else
            return false;
    }

    public void Heal()
    {
        int healAmount = damage / 2;

        currentHP += healAmount;
    }
}
