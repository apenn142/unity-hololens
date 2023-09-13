using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCooking : MonoBehaviour {
	[SerializeField] GameObject MainMenuPanel;
	[SerializeField] GameObject SecondMenuPanel;
	[SerializeField] AudioSource audioManager;
	// Use this for initialization
	void Start () {
		
	}
	void OnSelect()
    {
		audioManager.clip = (Resources.Load<AudioClip>("mixkit-software-interface-start-2574"));
		audioManager.Play();
		MainMenuPanel.SetActive(false);
		SecondMenuPanel.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
