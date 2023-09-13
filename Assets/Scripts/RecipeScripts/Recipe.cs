using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Recipe : MonoBehaviour
{
    public List<string> m_steps;
    public List<Ingredient> m_ingredients;
    public bool m_favorite = false;
    public int m_servings;
    public string m_name;
    public string m_info;
    public string m_image;
    public Recipe(string recipeName)
    {
        //TODO: Read file info into recipe class
        string filename = Application.dataPath + "/StreamingAssets/Recipes/" + recipeName + ".txt";
        if (!File.Exists(filename))
            Application.Quit();

        m_favorite = false;
        m_name = recipeName;
        m_steps = new List<string>();
        m_ingredients = new List<Ingredient>();
        m_info = "";

        int type = -1;

        foreach (string line in File.ReadAllLines(filename))
        {
            if (line.Equals("#Steps"))
            {
                type = 0;
                continue;
            }
            else if (line.Equals("#Ingredients"))
            {
                type = 1;
                continue;
            }
            else if (line.Equals("#Servings"))
            {
                type = 2;
                continue;
            }
            else if (line.Equals("#Favorite"))
            {
                type = 3;
                continue;
            }
            else if (line.Equals("#Info"))
            {
                type = 4;
                continue;
            }
            else if (line.Equals("#Image"))
            {
                type = 5;
                continue;
            }

            switch (type)
            {
                case 0:
                    m_steps.Add(line);
                    break;
                case 1:
                    Ingredient new_ingredient = Ingredient.parseIngredient(line);
                    m_ingredients.Add(new_ingredient);
                    break;
                case 2:
                    m_servings = int.Parse(line);
                    break;
                case 3:
                    m_favorite = bool.Parse(line);
                    break;
                case 4:
                    m_info = line;
                    break;
                case 5:
                    m_image= line;
                   
                    break;
            }

        }

        m_steps.Add("Congratulations! You have completed this recipe. Enjoy your " + m_name);
    }
}

public class Ingredient
{
    public Fraction m_amount;
    public string m_unit;
    public string m_name;

    public Ingredient(Fraction amount, string unit, string name)
    {
        m_amount = amount;
        m_unit = unit;
        m_name = name;
    }

    public static Ingredient parseIngredient(string ingredient)
    {
        string[] splitIngredient = ingredient.Split(',');

        if (splitIngredient.Length == 3)
            return new Ingredient(Fraction.parse(splitIngredient[0]), splitIngredient[1], splitIngredient[2]);
        else if (splitIngredient.Length == 2)
            return new Ingredient(Fraction.parse(splitIngredient[0]), "", splitIngredient[1]);
        else if (splitIngredient.Length == 1)
            return new Ingredient(new Fraction(0, 0, 0), "", splitIngredient[0]);
        else
            return null;
    }

    public string toString()
    {
        return m_amount.toString() + " " + m_unit + " " + m_name;
    }

    public string toStringScaled(Fraction f)
    {
        return Fraction.multiply(f, m_amount).toString() + " " + m_unit + " " + m_name;
    }
}

public class Fraction
{
    public int m_whole;
    public int m_numerator;
    public int m_denominator;

    public Fraction(int whole, int numerator, int denominator)
    {
        m_whole = whole;
        m_numerator = numerator;
        m_denominator = denominator;
    }

    public Fraction(int numerator, int denominator)
    {
        m_whole = 0;
        m_numerator = numerator;
        m_denominator = denominator;
    }

    public Fraction() { }

    public string toString()
    {
        string output = "";

        if (m_whole > 0)
            output += m_whole;

        if (m_whole > 0 && m_numerator > 0)
            output += " ";

        if (m_numerator > 0)
            output += m_numerator + "/" + m_denominator;

        return output;
    }

    public static Fraction multiply(Fraction f1, Fraction f2)
    {
        int new_numerator = (f1.m_numerator + f1.m_whole * f1.m_denominator) * (f2.m_numerator + f2.m_whole * f2.m_denominator);
        int new_denominator = f1.m_denominator * f2.m_denominator;
        return reduce(simplify(new Fraction(0, new_numerator, new_denominator)));
    }

    public static Fraction reduce(Fraction f)
    {
        int gcd = 1;

        for (int i = 1; i < f.m_numerator + 1; i++)
        {
            if (f.m_numerator % i == 0 && f.m_denominator % i == 0)
                gcd = i;
        }

        f.m_numerator /= gcd;
        f.m_denominator /= gcd;

        return f;
    }

    public static Fraction simplify(Fraction f)
    {
        f.m_whole += f.m_numerator / f.m_denominator;
        f.m_numerator %= f.m_denominator;
        return f;
    }

    public static Fraction parse(string fraction)
    {
        string[] s = fraction.Split(' ');
        int whole = 0;
        int num = 0;
        int denom = 1;
        string[] s2 = null;

        if (s.Length == 2)
        {
            whole = int.Parse(s[0]);
            s2 = s[1].Split('/');
            num = int.Parse(s2[0]);
            denom = int.Parse(s2[1]);
        }
        else if (s.Length == 1)
        {
            s2 = s[0].Split('/');
            if (s2.Length == 2)
            {
                num = int.Parse(s2[0]);
                denom = int.Parse(s2[1]);
            }
            else
                whole = int.Parse(s2[0]);
        }

        return new Fraction(whole, num, denom);
    }
}
