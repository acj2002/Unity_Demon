using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HPBarBoss : MonoBehaviour
{
    public Slider slider;
    public void setMaxHpboss(int Hp)
    {
        slider.maxValue = Hp;
        slider.value = Hp;

    }
    public void setHpboss(int Hp)
    {
        slider.value = Hp;
    }



}
