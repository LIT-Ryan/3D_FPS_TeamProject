using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
	public Slider slider;
	PlayerController charPower;

	public void SetMaxPower(int power)

	{
		slider.maxValue = power;
		slider.value = power;

	}

	public void SetPower(int power)
	{
		slider.value = power;
	}


	void Update()
	{
		charPower = FindObjectOfType<PlayerController>();

		slider.value = charPower.currentPower;


	}
}
