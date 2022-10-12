using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : CharacterInfo
{
    //string Cname
    //int level
    //int damage
    //int maxhp
    //int currenthp

    public int knowledge;

    public bool isDead;
    public bool isStarting;
    public bool changedScene;
    public string lastScene;
    public float lastCordX;
    public float lastCordY;

    public void UpdateStats(Player player)
    {
        this.level = player.level;
        this.damage = player.damage;
        this.maxHP = player.maxHP;
        this.currentHP = player.currentHP;
        this.knowledge = player.knowledge;
    }

    public void ChangeStats(int level, int damage, int maxHP, int currentHP, int knowledge)
    {
        this.level += level;
        this.damage += damage;
        this.maxHP += maxHP;
        this.currentHP += currentHP;
        this.knowledge += knowledge;

        if(this.currentHP > this.maxHP)
        {
            this.currentHP = this.maxHP;
        }
    }

    public void SetStats(Player player)
    {
        this.level = player.level;
        this.damage = player.damage;
        this.maxHP = player.maxHP;
        this.currentHP = player.currentHP;
        this.knowledge = player.knowledge;
    }

    public void SaveLocation(string lastScene, float lastCordX, float lastCordY)
    {
        this.lastScene = lastScene;
        this.lastCordX = lastCordX;
        this.lastCordY = lastCordY;
        changedScene = true;
    }

    public void resetPlayer()
    {
        this.level = 1;
        this.damage = 10;
        this.maxHP = 60;
        this.currentHP = 60;
    }

    public Vector3 GetLocation()
    {
        return new Vector3(lastCordX, lastCordY, 0);
    }

    public Player GetPlayer()
    {
        return this;
    }
}
