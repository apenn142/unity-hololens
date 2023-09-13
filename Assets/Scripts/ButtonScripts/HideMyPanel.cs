using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMyPanel : MonoBehaviour {
	[SerializeField] GameObject myPanel;
	// Use this for initialization
	void Start () {
		
	}
	void OnSelect()
    {
		myPanel.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
