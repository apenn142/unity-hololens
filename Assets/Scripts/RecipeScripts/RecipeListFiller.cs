using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class RecipeListFiller : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Text textPrefab;
    [SerializeField] private GameObject recipePrefab;
    [SerializeField] private GameObject spawnObject;
    [SerializeField] private GameObject panelPrefab;

    [SerializeField] private GameObject nextButton;
    [SerializeField] private GameObject previousButton;
    private float inc = -.02f;
    private List<GameObject> pages;
    private int activePage = 0;
    

    public void fillRecipeList()
    {
        Debug.Log("infill");
        //activePage = 0;
        Vector3 spawnPoint = spawnObject.transform.position;
       //panelPrefab.transform.parent = parent.transform;
        List<Recipe> favorites = gameObject.GetComponent<MenuManager>().favorites;
        List<Recipe> allRecipes = gameObject.GetComponent<MenuManager>().allRecipes;
        Debug.Log(allRecipes.Count);
        int numPages = (int)Math.Ceiling((favorites.Count + allRecipes.Count) / 4f);

        pages = new List<GameObject>();
        for (int i = 0; i < numPages; i++)
        {
            GameObject temp = Instantiate(panelPrefab, spawnPoint - new Vector3(0, .2f, 0), Quaternion.identity, parent);
            temp.transform.localRotation = parent.transform.localRotation;
            pages.Add(temp);

        }
           
        
        int pageNum = 1;
        int numRecipes = 0;
        Debug.Log("favs: " + favorites.Count);
        if (favorites.Count > 0)
        {
            Text favoritesText = Instantiate(textPrefab, spawnPoint, Quaternion.identity, pages[pageNum - 1].transform);
            favoritesText.transform.rotation = pages[pageNum - 1].transform.rotation;
            favoritesText.text = "Favorites";
            spawnPoint += new Vector3(0, -.06f, 0);

            for (int i = 0; i < favorites.Count; i++)
            {
                Debug.Log("favorites");
                instantiateRecipe(favorites[i], spawnPoint, pages[pageNum - 1]);

                numRecipes++;
                if (numRecipes >= pageNum * 4)
                {
                    pageNum++;
                    spawnPoint = spawnObject.transform.position;
                }
                else
                    spawnPoint += new Vector3(0, -.07f, 0);
            }
        }
        Debug.Log(allRecipes[0].m_name);
        Text recipeText = Instantiate(textPrefab, spawnPoint, Quaternion.identity, pages[pageNum - 1].transform);
        recipeText.transform.rotation = pages[pageNum - 1].transform.rotation;
        recipeText.text = "All Recipes";
        spawnPoint += new Vector3(0, -.06f, 0);


        for (int i = 0; i < allRecipes.Count; i++)
        {
            Debug.Log(allRecipes[i]);
            instantiateRecipe(allRecipes[i], spawnPoint, pages[pageNum - 1]);

            numRecipes++;
            if (numRecipes >= pageNum * 4)
            {
                pageNum++;
                spawnPoint = spawnObject.transform.position;
                spawnPoint += new Vector3(0, -.08f, 0);
            }
            else
                spawnPoint += new Vector3(0, -.10f,0);
        }

        nextButton.transform.SetParent(pages[0].transform);
        previousButton.transform.SetParent(pages[0].transform);

        if (numPages > 1)
            nextButton.SetActive(true);

       
        //openPage();
    }

    public void openPage()
    {
        Debug.Log("ac: " + pages[activePage] + activePage);
        gameObject.GetComponent<MenuManager>().ActivateSubMenu(pages[activePage]);
    }

    public void changePage(int increment)
    {
        Debug.Log("page count is: " + pages.Count);
        if (activePage + increment < 0 || activePage + increment >= pages.Count)
            return;
        Debug.Log("1active page is: " + activePage);
        Debug.Log("ins is: " + increment);
        activePage += increment;
        Debug.Log("2active page is: " + activePage);
        nextButton.transform.SetParent(pages[activePage].transform);
        previousButton.transform.SetParent(pages[activePage].transform);
        Debug.Log("3active page is: " + activePage);
        if (activePage == 0)
            previousButton.SetActive(false);
        else
            previousButton.SetActive(true);
        Debug.Log("active page is: " + activePage);
        if (activePage == pages.Count - 1)
            nextButton.SetActive(false);
        else
            nextButton.SetActive(true);
    }
    private void instantiateRecipe(Recipe recipe, Vector3 spawnPoint, GameObject page)
    {
        
        if (spawnPoint == null)
        {
            Debug.Log("spawnpoint");
        }
        if (recipe == null)
        {
            Debug.Log("recipe");
          
        }
        if (page == null)
        {
            Debug.Log("page");
        }
        if (recipePrefab == null)
        {
            Debug.Log("recipeprefab");
        }
        GameObject recipeObject = Instantiate(recipePrefab, spawnPoint, Quaternion.identity, page.transform);
        recipeObject.transform.parent = page.transform;
        recipeObject.transform.localPosition = new Vector3(recipeObject.transform.localPosition.x, recipeObject.transform.localPosition.y, 0);
        
        recipeObject.transform.rotation = page.transform.rotation;
        recipeObject.GetComponent<RecipeSelection>().recipe = recipe;
        recipeObject.transform.Find("RecipeName").GetComponent<Text>().text = recipe.m_name.Replace("_", " ");
        recipeObject.transform.Find("RecipeInfo").GetComponent<Text>().text = recipe.m_info;

        string filename = "Images/" + recipe.m_name;
        //Debug.Log(filename);
        recipeObject.transform.Find("Image").GetComponent<Image>().sprite = Resources.Load<Sprite>(filename);
    }

    public void emptyRecipeList()
    {
        
        MenuManager.pastfirstStart = true;
        for (int i = 0; i < pages.Count; i++)
        {
            if (i != activePage)
                pages[i].SetActive(true);
        }
        GameObject[] recipes = GameObject.FindGameObjectsWithTag("Recipe");

        for (int i = 0; i < recipes.Length; i++)
        {
            Debug.Log("desrotying recipe");
            Destroy(recipes[i]);
        }

        GameObject[] recipeText = GameObject.FindGameObjectsWithTag("RecipeText");
        for (int i = 0; i < recipeText.Length; i++)
        {
            Debug.Log("desrotying recipe text");
            Destroy(recipeText[i]);
        }
    }
    public void Update()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            if(i!=activePage)
            pages[i].SetActive(false);
        }
        Debug.Log(activePage);

    }
}
