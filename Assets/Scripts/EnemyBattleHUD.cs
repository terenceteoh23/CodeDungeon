using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBattleHUD : MonoBehaviour
{
    public Text enemyName;
    public Slider hpSlider;

    public void SetHUD(CharacterInfo info)
    {
        enemyName.text = info.Cname;
        hpSlider.maxValue = info.maxHP;
        hpSlider.value = info.currentHP;

    }

    public void SetHp(int hp)
    {
        hpSlider.value = hp;
    }
}
