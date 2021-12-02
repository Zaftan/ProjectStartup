using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{
    public List<Ingredient> ingredients;
    public GameObject prefab;

    void Start()
    {
        /*foreach (Ingredient ingredient in ingredients)
        {
            prefab.GetComponent<IngredientDisplay>().ingredient = ingredient;
            Instantiate(prefab, gameObject.transform);
        }*/
    }
}
