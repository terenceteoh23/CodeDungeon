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

    public void SetPlayerInfo(Player player)
    {
        hpSlider.maxValue = player.maxHP;
        hpSlider.value = player.currentHP;
        hpText.text = player.currentHP + "/" + player.maxHP;
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
