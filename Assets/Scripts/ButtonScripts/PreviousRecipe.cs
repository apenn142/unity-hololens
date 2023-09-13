using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousRecipe : MonoBehaviour {
	[SerializeField] private MenuManager mm;
	private int count = 0;
	// Use this for initialization
	void Start()
	{

	}
	void OnSelect()
	{
		if (count % 2 == 0)
			mm.GetComponent<RecipeListFiller>().changePage(-1);
		mm.GetComponent<RecipeListFiller>().openPage();
		count++;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
