using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IngredientDisplay : MonoBehaviour
{
    Button button;
    public Ingredient ingredient;

    public Text ingredientName;
    public Text ingredientPrice;

    public Image ingredientImage;

    void Start()
    {
        ingredientName.text = ingredient.ingredientName;
        ingredientPrice.text = ingredient.price.ToString();
        ingredientImage.sprite = ingredient.ingredient;

        button = GetComponent<Button>();
        Transform detailDisplay = GameObject.FindGameObjectWithTag("Canvas").transform.Find("IngredientDetail");
        DetailScript details = detailDisplay.GetComponent<DetailScript>();
        button.onClick.AddListener(delegate { details.SetDetails(ingredient); });
    }
}
