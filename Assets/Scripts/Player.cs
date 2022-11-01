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
    //int exp

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
        this.exp = player.exp;
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
        this.damage = 5;
        this.maxHP = 100;
        this.currentHP = 100;
        this.isDead = false;
    }

    public Vector3 GetLocation()
    {
        return new Vector3(lastCordX, lastCordY, 0);
    }

    public Player GetPlayer()
    {
        return this;
    }

    public string SaveData()
    {
        return level + "|" + damage + "|" + maxHP + "|" + currentHP + "|" + knowledge;
    }

    public void LoadData(string data)
    {
        string[] arr = data.Split("|");

        level = int.Parse(arr[0]);
        damage = int.Parse(arr[1]);
        maxHP = int.Parse(arr[2]);
        currentHP = int.Parse(arr[3]);
        knowledge = int.Parse(arr[4]);

    }
}
