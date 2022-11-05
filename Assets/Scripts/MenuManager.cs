using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject menu;

    public Slider hpSlider;
    public Slider expSlider;
    public Text hpText;
    public Text expText;
    public Text levelText;

    public void SetPlayerInfo(Player player, List<int> index)
    {
        hpSlider.maxValue = player.maxHP;
        hpSlider.value = player.currentHP;
        hpText.text = player.currentHP + "/" + player.maxHP;

        expSlider.maxValue = index[player.level];
        expSlider.minValue = index[player.level - 1];
        expSlider.value = player.exp;
        expText.text = (expSlider.maxValue - player.exp) + "to Next Level";

        levelText.text = "Level " + player.level + ":";
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
    }

    public void HideMenu()
    {
        menu.SetActive(false);
    }
}
