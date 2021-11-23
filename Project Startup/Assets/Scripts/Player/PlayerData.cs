using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public int money;
    public int blue, red, green = 0;

    [SerializeField] Text ballanceText;

    void Start()
    {
        DontDestroyOnLoad(gameObject);   
    }

    void Update()
    {
        ballanceText.text = money.ToString();
    }

    public void Sell(int moneyToAdd) {
        money += moneyToAdd;
    }

    public void Buy(int moneyToRemove)
    {
        money -= moneyToRemove;
    }

    public void IngredientStock(Ingredient ingredient)
    {
        if(ingredient.ingredientName == "Blue")
        {
            blue++;
        }
        if(ingredient.ingredientName == "Green")
        {
            green++;
        }
        if(ingredient.ingredientName == "Red")
        {
            red++;
        }
    }
}
