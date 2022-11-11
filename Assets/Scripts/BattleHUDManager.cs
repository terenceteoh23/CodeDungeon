using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUDManager : MonoBehaviour
{
    //player and enemy hud
    public PlayerBattleHUD playerHUD;
    public EnemyBattleHUD enemyHUD;

    //battle hud text
    public Text battleDialog;

    //secondary battle hud
    public GameObject SecondBattleHUD;

    //inventory hud
    public GameObject InventoryHUD;

    public void BattleSetup(Player p, CharacterInfo e)
    {
        playerHUD.SetHUD(p);
        enemyHUD.SetHUD(e);
    }

    public void UpdateBattleDialog(string s)
    {
        battleDialog.text = s;
    }

    public void ShowSecondBattleHUD()
    {
        SecondBattleHUD.SetActive(true);
    }

    public void HideSecondBattleHUD()
    {
        SecondBattleHUD.SetActive(false);
    }

    public void ShowInventory()
    {
        InventoryHUD.SetActive(true);
    }

    public void HideInventory()
    {
        InventoryHUD.SetActive(false);
    }


}
