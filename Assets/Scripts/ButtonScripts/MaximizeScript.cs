using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaximizeScript : MonoBehaviour {
	[SerializeField] GameObject MinimizedPanel;
	GameObject LastUsedPanel;
	// Use this for initialization
	void Start()
	{
		
		
		
	}
	void OnSelect()
	{
		LastUsedPanel = MinimizeScript.ThisActivePanel;

		LastUsedPanel.SetActive(true);
		MinimizedPanel.SetActive(false);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
