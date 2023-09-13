using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousButton : MonoBehaviour {
	[SerializeField] private MenuManager m;
	private int count = 0;
	// Use this for initialization
	void Start()
	{

	}
	void OnSelect()
	{
		if(count % 2 == 0)
		m.changeStep(-1);
		count++;
	}
	// Update is called once per frame
	void Update()
	{

	}
}
