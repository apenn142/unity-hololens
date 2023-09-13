using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourS : MonoBehaviour {
	[SerializeField] private ServingKeyboard sk;
	private int count = 0;
	// Use this for initialization
	void Start()
	{

	}
	void OnSelect()
	{
		if (count % 2 == 0)
			sk.onClick(4);
		count++;
	}
}
