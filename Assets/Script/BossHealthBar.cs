using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossHealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetBossMaxHealth(int curHP)
    {
        slider.maxValue = curHP;
        slider.value = curHP;
    }
    public void SetBossHealth(int curHp)
    {
        slider.value = curHp;
    }
}
