using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeSelection : MonoBehaviour
{
    public Recipe recipe;
    public void openRecipe()
    {
       // 
        
    }
    void OnSelect()
    {
        GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().SwapMenus();
        GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().currentStep = 0;

        GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().activeRecipe = recipe;
        GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().RecipeName.text = recipe.m_name;
        MenuManager.CloseSubMenus();
    }
    public void Quit()
    {
        Application.Quit();
    }
}
