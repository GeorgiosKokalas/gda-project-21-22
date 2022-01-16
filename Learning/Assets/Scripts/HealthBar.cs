using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public float destination = 0;
    public float journey = 0;
	public Image fill;
    public float timeFlow = 0;

    public void SetMaxHealth(float health, float startingHealth){
		slider.maxValue = health;
		slider.value = startingHealth;

    }

    public void SetHealth(float health)
	{
		slider.value = health;
    }
}
