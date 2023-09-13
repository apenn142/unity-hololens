using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeMenu : MonoBehaviour
{
    [SerializeField] private Text stepText;
    [SerializeField] private Text fullStepText;

    private void Update()
    {
        int currentStep = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().currentStep;
        string text = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().activeRecipe.m_steps[currentStep];

        fullStepText.text = text;

        if (text.Length > 50)
            text = text.Substring(0, 49) + " ...";

        if (currentStep + 1 != GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>().activeRecipe.m_steps.Count)
        {
            text = "Step " + (currentStep + 1) + ": " + text;
            fullStepText.text = "Step " + (currentStep + 1) + ": " + fullStepText.text;
        }

        stepText.text = text;

    }
}
