using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour {
	[SerializeField] TimerHandler th;
	// Use this for initialization
	void Start()
	{

	}
	void OnSelect()
	{
		th.deleteTimer();
	}
	// Update is called once per frame
	void Update () {
		
	}
}
