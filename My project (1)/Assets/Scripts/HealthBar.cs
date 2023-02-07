using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;


    public void SetMaxHealth(int health)
    {
        //set the players slider max value to the healths max value
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        //set the players slider value to the current health value
        slider.value = health;
    }
}
