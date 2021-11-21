using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientDisplay : MonoBehaviour
{
    public Ingredient ingredient;

    public Text ingredientName;
    public Text ingredientPrice;

    public Image ingredientImage;

    void Start()
    {
        ingredientName.text = ingredient.ingredientName;
        ingredientPrice.text = ingredient.price.ToString();
        ingredientImage.sprite = ingredient.ingredient;
    }
}
