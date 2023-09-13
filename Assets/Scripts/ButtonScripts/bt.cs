using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bt : MonoBehaviour {
	[SerializeField] public GameObject MainMenuPanel;
	// Use this for initialization
	void Start () {
		
	}
	void OnSelect()
    {
		MainMenuPanel.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
