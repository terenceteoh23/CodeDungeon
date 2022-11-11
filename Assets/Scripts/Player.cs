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

    public int nextLevel;
    public int knowledge;

    public bool isDead;
    public bool isStarting;
    public bool changedScene;
    public string lastScene;
    public float lastCordX;
    public float lastCordY;

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
        this.isStarting = true;
        this.isDead = false;
        this.exp = 0;
        this.nextLevel = 15;
    }

    public void SetEXP(int exp)
    {
        this.exp += exp;
    }
    public int GetEXP()
    {
        return exp;
    }

    public void LevelUp(List<int> index)
    {
        this.level++;
        this.damage += 2*level;
        this.maxHP += 5*level;
        this.currentHP += 5 * level;
        if (this.level < 10)
        {
            this.nextLevel = index[level];
        }
        else
        {
            this.nextLevel = 0;
        }
    }
    public Vector3 GetLocation()
    {
        return new Vector3(lastCordX, lastCordY, 0);
    }

    public string SaveData()
    {
        return level + "|" + damage + "|" + maxHP + "|" + currentHP + "|" + knowledge + "|" + exp + "|" + nextLevel;
    }

    public void LoadData(string data)
    {
        string[] arr = data.Split("|");

        level = int.Parse(arr[0]);
        damage = int.Parse(arr[1]);
        maxHP = int.Parse(arr[2]);
        currentHP = int.Parse(arr[3]);
        knowledge = int.Parse(arr[4]);
        exp = int.Parse(arr[5]);
        nextLevel = int.Parse(arr[6]);

    }
}
