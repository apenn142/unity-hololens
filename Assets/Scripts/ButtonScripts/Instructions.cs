using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour {
	[SerializeField] GameObject hiddenInstructions;
	[SerializeField] GameObject shownInstructions;
	private bool showing = false;
	private int counter = 0;
	// Use this for initialization
	void Start () {
		
	}
	void OnSelect()
	{
		if (!showing )
		{

			hiddenInstructions.SetActive(false);
			shownInstructions.SetActive(true);
			showing = true;
		}
		else if (showing )
		{
			shownInstructions.SetActive(false);
			hiddenInstructions.SetActive(true);
			showing = false;
		}
		counter++;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
