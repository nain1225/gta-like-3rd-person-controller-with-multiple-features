using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void setHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void getHealth(float health)
    {
        //slider.maxValue = health;
        slider.value = health;
    }
}
