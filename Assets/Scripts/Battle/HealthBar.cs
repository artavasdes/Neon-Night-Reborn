using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;
	public GameObject icon;
	public bool taken = false;

	public void SetVisible() {
		gameObject.SetActive(true);
		icon.SetActive(true);
		taken = true;
		// Debug.Log(1);
	}

	public void SetMaxHealth(int health)
	{
		slider.maxValue = health;
		slider.value = health;
		

		fill.color = gradient.Evaluate(1f);
	}

    public void SetHealth(int health)
	{
		slider.value = health;
		if (health < 0){
			slider.value = 0; 
		}

		fill.color = gradient.Evaluate(slider.normalizedValue);
	}

}
