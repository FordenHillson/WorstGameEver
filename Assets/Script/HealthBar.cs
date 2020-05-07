using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int curHP)
    {
        slider.maxValue = curHP;
        slider.value = curHP;
    }
    public void SetHealh(int curHp)
    {
        slider.value = curHp;
    }
}
