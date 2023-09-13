using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServingKeyboard : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private IngredientsHandler ingredientsHandler;
    string buffer = "0";

    public void onClick(int code)
    {
        if (buffer.Equals("0"))
            buffer = "";

        if (code >= 0)
            buffer += code;
        else if (code == -1)
        {
            if (buffer.Length > 0)
                buffer = buffer.Substring(0, buffer.Length - 1);
        }
        else if (code == -2)
            buffer = "0";

        text.text = buffer;
    }

    public void applyBuffer()
    {
        int newServings = int.Parse(buffer);
        ingredientsHandler.servings = newServings;
        buffer = "0";
        text.text = buffer;
    }
}

