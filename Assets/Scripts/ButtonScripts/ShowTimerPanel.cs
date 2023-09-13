using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTimerPanel : MonoBehaviour {
	[SerializeField] GameObject timerPanel;
	// Use this for initialization
	void Start () {
		
	}
	void OnSelect()
    {
		timerPanel.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
