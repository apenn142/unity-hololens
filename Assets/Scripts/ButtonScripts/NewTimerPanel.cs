using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTimerPanel : MonoBehaviour {
	[SerializeField] private GameObject myNewTimerPanel;
	[SerializeField] private GameObject timerOptionsPanel;
	// Use this for initialization
	void Start () {
		
	}
	void OnSelect()
    {
		myNewTimerPanel.SetActive(true);
		timerOptionsPanel.SetActive(false);

	}
	// Update is called once per frame
	void Update () {
		
	}
}
