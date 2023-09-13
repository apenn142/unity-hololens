using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitApp : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	void OnSelect()
    {
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
	}
	// Update is called once per frame
	void Update () {
		
	}
}
