using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public int MaxValue = 5;
    public Slider slider;
    
    //Sets the health bar UI element to the players health
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
