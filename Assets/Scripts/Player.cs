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

    public Vector3 GetLocation()
    {
        return new Vector3(lastCordX, lastCordY, 0);
    }

    public Player GetPlayer()
    {
        return this;
    }

    /*public void SaveState()
    {
        string s = "";

        s += Cname + "|";
        s += level.ToString() + "|";
        s += damage.ToString() + "|";
        s += maxHP.ToString() + "|";
        s += currentHP.ToString() + "|";
        s += knowledge.ToString();

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState()
    {
        if (!PlayerPrefs.HasKey("SaveState"))
        {

            return;
        }

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        Cname = data[0];
        level = int.Parse(data[1]);
        damage = int.Parse(data[2]);
        maxHP = int.Parse(data[3]);
        currentHP = int.Parse(data[4]);
        knowledge = int.Parse(data[5]);

    }*/
}
