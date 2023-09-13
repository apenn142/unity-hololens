using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonCommands : MonoBehaviour {
	[SerializeField] private Button thisButton;
	// Use this for initialization
	void Start () {
		
	}
	public void OnSelect()
	{
		Debug.Log("yep1");
		thisButton.onClick.Invoke();
		Debug.Log("yep2");

	}
	// Update is called once per frame
	void Update () {
		
	}
}
