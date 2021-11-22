using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailScript : MonoBehaviour
{
    string ingj;

    public Text ingredientName;
    public Text ingredientPrice;

    public Image ingredientImage;

    public void SetDetails(Ingredient ingredient)
    {
        ingredientName.text = ingredient.ingredientName;
        ingj = ingredient.ingredientName;
        ingredientPrice.text = ingredient.price.ToString();
        ingredientImage.sprite = ingredient.ingredient;
    }

    public void BuyIngredient()
    {
        Debug.Log("Bought ingredient: " + ingj);
    }
}
