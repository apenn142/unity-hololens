using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FavoriteRecipe : MonoBehaviour {

	//[SerializeField] Sprite checkmark;
	//GameObject parentPanel;
	private int count = 0;
	[SerializeField] MenuManager mm;
	// Use this for initialization
	void Start () {
		//parentPanel = gameObject.transform.parent.gameObject; 
		
	}
	void OnSelect()
    {
		if(count%2==0)
		mm.toggleFavorite();
		//gameObject.GetComponentInChildren<Image>().sprite = checkmark;
		//FavoriteManager.favoriteRecipes[FavoriteManager.favoriteRecipeCount] = parentPanel;
		//FavoriteManager.favoriteRecipeCount++;
		count++;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
