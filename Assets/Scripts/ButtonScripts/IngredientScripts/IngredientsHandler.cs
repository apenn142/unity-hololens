using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientsHandler : MonoBehaviour
{
    [SerializeField] private Text ingredientList;
    [SerializeField] private Text servingText;

    public int servings = -1;
    void Update()
    {
        Recipe recipe = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().activeRecipe;

        string text = "";

        for (int i = 0; i < recipe.m_ingredients.Count; i++)
        {
            Debug.Log(recipe.m_ingredients.Count);
            if (servings == -1)
                text += recipe.m_ingredients[i].toString() + "\n";
            else
            {
                Fraction servingsScale = new Fraction(servings, recipe.m_servings);
                text += recipe.m_ingredients[i].toStringScaled(servingsScale) + "\n";
            }
        }

        if (servings == -1)
            servingText.text = "Servings: " + recipe.m_servings;
        else
            servingText.text = "Servings: " + servings;

        ingredientList.text = text;
    }
}

