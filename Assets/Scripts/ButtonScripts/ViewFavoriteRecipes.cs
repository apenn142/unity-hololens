using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFavoriteRecipes : MonoBehaviour {
	[SerializeField] GameObject secondMenuPanel;
	[SerializeField] GameObject FavoriteRecipeListPanel;
	// Use this for initialization
	void Start()
	{

	}
	void OnSelect()
	{
		secondMenuPanel.SetActive(false);
		FavoriteRecipeListPanel.SetActive(true);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
