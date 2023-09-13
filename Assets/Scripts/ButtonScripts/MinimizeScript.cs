using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MinimizeScript : MonoBehaviour {
	 public static GameObject ThisActivePanel;
	[SerializeField] GameObject Panel;
	[SerializeField] GameObject MinimizedPanel;
	// Use this for initialization
	void Start () {

		
		
	}
	void OnSelect()
    {
		ThisActivePanel = Panel;
		
		ThisActivePanel.SetActive(false);
		MinimizedPanel.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
