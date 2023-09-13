using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewAllRecipes : MonoBehaviour {
	[SerializeField] GameObject secondMenuPanel;
	[SerializeField] GameObject allRecipeListPanel;
	[SerializeField] MenuManager mm;
	// Use this for initialization
	void Start () {
		
	}
	void OnSelect()
    {
		Debug.Log("viewieing all recipes");
		secondMenuPanel.SetActive(false);
		allRecipeListPanel.SetActive(true);
		//mm.GetComponent<RecipeListFiller>().openPage();
        if (MenuManager.pastfirstStart)
        {
			//mm.OnStart();
			mm.GetComponent<RecipeListFiller>().fillRecipeList();
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
