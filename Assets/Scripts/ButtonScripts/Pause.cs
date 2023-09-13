using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
	[SerializeField] TimerHandler th;
	private int count = 0;
	// Use this for initialization
	void Start()
	{

	}
	void OnSelect()
	{
		if(count%2==0)
		th.pauseTimer();
		count++;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
