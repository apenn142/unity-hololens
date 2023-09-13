using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour {
	[SerializeField] TimerHandler th;
	// Use this for initialization
	void Start () {
		
	}
	void OnSelect()
    {
		th.resetTimer();
    }
	// Update is called once per frame
	void Update () {
		
	}
}
