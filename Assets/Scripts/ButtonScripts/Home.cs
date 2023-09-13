using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour {

	// Use this for initialization
	GameObject thisPanel;
	[SerializeField] GameObject SecondMenuPanel;
	void Start () {
		thisPanel = gameObject.transform.parent.gameObject;
	}
	void OnSelect()
    {
		SecondMenuPanel.SetActive(true);
		thisPanel.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
