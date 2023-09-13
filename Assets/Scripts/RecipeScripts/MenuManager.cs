using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject RecipeMenu;
    [SerializeField] private GameObject HeartIcon;
    public static bool pastfirstStart = false;
    public Text RecipeName;
    public Recipe activeRecipe = null;
    public int currentStep = -1;

    public List<Recipe> favorites;
    public List<Recipe> allRecipes;

    private void Start()
    {
        OnStart();
        Debug.Log("onstartin manager");
    }

    public void ActivateSubMenu(GameObject submenu)
    {
        bool submenuActive = submenu.activeSelf;

        CloseSubMenus();

        if (!submenuActive)
            submenu.SetActive(true);
    }

    public void OnStart()
    {
       
        favorites = new List<Recipe>();
        allRecipes = new List<Recipe>();

        string dirname = Application.dataPath + "/StreamingAssets/Recipes/";

        foreach (string recipeFilepath in Directory.GetFiles(dirname))
        {
            string[] splitFilePath = recipeFilepath.Split('/');
            // Debug.Log(recipeFilepath);
            if (!splitFilePath[splitFilePath.Length - 1].EndsWith(".txt"))
                continue;

            string recipeName = splitFilePath[splitFilePath.Length - 1].Replace(".txt", "");
            //Debug.Log(recipeName);
            Recipe recipe = new Recipe(recipeName);
            //Debug.Log(recipe.m_name);
            allRecipes.Add(recipe);
            // Debug.Log(allRecipes.Count);
            if (recipe.m_favorite)
                favorites.Add(recipe);
        }
        Debug.Log("in onstart going to fill recipe");
        gameObject.GetComponent<RecipeListFiller>().fillRecipeList();
    }

    public void ToggleSubMenu(GameObject submenu)
    {
        bool wasActive = submenu.activeSelf;
        GameObject[] submenus = GameObject.FindGameObjectsWithTag("SubSubMenu");

        for (int i = 0; i < submenus.Length; i++)
        {
            submenus[i].SetActive(false);
        }

        submenu.SetActive(!wasActive);
    }

    public static void CloseSubMenus()
    {
        GameObject[] submenus = GameObject.FindGameObjectsWithTag("SubMenu");

        for (int i = 0; i < submenus.Length; i++)
        {
            submenus[i].SetActive(false);
        }

        submenus = GameObject.FindGameObjectsWithTag("SubSubMenu");

        for (int i = 0; i < submenus.Length; i++)
        {
            submenus[i].SetActive(false);
        }
    }

    public void closeRecipe()
    {
        activeRecipe = null;
        currentStep = -1;
        CloseSubMenus();
        SwapMenus();


    }

    public void SwapMenus()
    {
        if (MainMenu.activeSelf)
        {
            gameObject.GetComponent<RecipeListFiller>().emptyRecipeList();
        }
        else
        {
            gameObject.GetComponent<RecipeListFiller>().fillRecipeList();
        }

        MainMenu.SetActive(!MainMenu.activeSelf);
        RecipeMenu.SetActive(!RecipeMenu.activeSelf);

    }

    public void changeStep(int increment)
    {
        if (currentStep + increment >= activeRecipe.m_steps.Count || currentStep + increment < 0)
            return;

        currentStep += increment;
    }
    public void toggleFavorite()
    {
        //Debug.Log("toggle1");
       
        activeRecipe.m_favorite = !activeRecipe.m_favorite;

        if (activeRecipe.m_favorite)
            favorites.Add(activeRecipe);
        else
            favorites.Remove(activeRecipe);
       // Debug.Log("toggle2");

        string filename = "Images/";

        if (!activeRecipe.m_favorite)
            filename += "icons-heart-96";
        else
            filename += "heartout";
        Debug.Log("toggle3");
        HeartIcon.GetComponent<Image>().sprite = Resources.Load<Sprite>(filename);
    }
}

