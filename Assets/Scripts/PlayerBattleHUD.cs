using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBattleHUD : MonoBehaviour
{
    public Text hpText;
    public Slider hpSlider;

    public void SetHUD(CharacterInfo info)
    {
        hpSlider.maxValue = info.maxHP;
        hpSlider.value = info.currentHP;
        hpText.text = hpSlider.value + "/" + hpSlider.maxValue; 
    }

    public void SetHp(int hp)
    {
        hpSlider.value = hp;
        hpText.text = hpSlider.value + "/" + hpSlider.maxValue;
    }
}       
