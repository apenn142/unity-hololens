using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour {
	private int counter = 0; //to counter the double clicking, only count every other press
	[SerializeField] private TimerKeyboard tk;

	void Start()
	{

	}
	void OnSelect()
	{
		if (counter % 2 == 0)
		{
			tk.applyTimer();
		}
		counter++;
	}
}
