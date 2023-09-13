using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Three : MonoBehaviour {
	private int counter = 0; //to counter the double clicking, only count every other press
	[SerializeField] private TimerKeyboard tk;

	void Start()
	{

	}
	void OnSelect()
	{
		if (counter % 2 == 0)
		{
			tk.onClick(3);
		}
		counter++;
	}
	// Update is called once per frame
	void Update()
	{

	}
}
