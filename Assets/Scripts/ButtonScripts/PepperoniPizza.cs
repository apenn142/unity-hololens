using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PepperoniPizza : MonoBehaviour {
	[SerializeField] GameObject PepperoniPizzaPanel;
	GameObject AllRecipeListPanel;
	// Use this for initialization
	void Start () {
		AllRecipeListPanel = GameObject.FindGameObjectWithTag("All");	
	}
	void OnSelect()
    {
		AllRecipeListPanel.SetActive(false);
		PepperoniPizzaPanel.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
