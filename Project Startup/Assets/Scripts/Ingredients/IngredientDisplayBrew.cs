using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientDisplayBrew : MonoBehaviour
{
    public Ingredient ingredient;

    public SpriteRenderer ingredientSprite;

    // Start is called before the first frame update
    void Start()
    {
        ingredientSprite.sprite = ingredient.ingredient;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}