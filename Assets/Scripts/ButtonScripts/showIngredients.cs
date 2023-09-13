using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class showIngredients : MonoBehaviour {
	[SerializeField] GameObject IngredientsPanel;
	// Use this for initialization
	void Start () {
		
	}
	void OnSelect()
    {
		IngredientsPanel.SetActive(true);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
