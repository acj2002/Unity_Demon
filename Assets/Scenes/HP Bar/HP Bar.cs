using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPBar : MonoBehaviour
{
    public Slider slider;
    public void setMaxHp(int Hp)
    {
        slider.maxValue = Hp;
        slider.value = Hp;

    }
    public void setHp(int Hp)
    {
        slider.value = Hp;
    }
}
