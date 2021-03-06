using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailScript : MonoBehaviour
{
    string ingj;
    int amount;

    int price;

    public Text ingredientName;
    public Text ingredientPrice;
    public Text currentAmount;

    public Image ingredientImage;

    public Slider amountSlider;

    public void SetDetails(Ingredient ingredient)
    {
        ingredientName.text = ingredient.ingredientName;
        ingj = ingredient.ingredientName;
        price = ingredient.price;
        ingredientPrice.text = ingredient.price.ToString();
        ingredientImage.sprite = ingredient.ingredient;

        amount = 1;

        amountSlider.maxValue =  Mathf.FloorToInt(PlayerData.instance.money / price);
        amountSlider.minValue = 1; 
    }

    private void Update()
    {
        currentAmount.text = amount.ToString();
        ingredientPrice.text = (price * amount).ToString();
    }

    public void BuyIngredient()
    {
        if (PlayerData.instance.money >= price * amount)
        {
            PlayerData.instance.buyIngredient(ingj, amount);
            PlayerData.instance.Buy(price * amount);
        }
    }

    public void PlusButtonBehaviour()
    {
        if (PlayerData.instance.money > price * amount)
        {
            amount++;
        }
    }

    public void MinusButtonBehaviour()
    {
        if (amount > 1)
        {
            amount--;
        }
    }
}
