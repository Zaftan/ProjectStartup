using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public PotionSO potionSO;

    public string potionName;
    public SpriteRenderer potionSprite;
    public List<Ingredient> ingredients;
    public int sellPrice;

    private void Start()
    {
        potionName = potionSO.name;
        potionSprite.sprite = potionSO.potionSprite;
        ingredients = potionSO.ingredients;
        sellPrice = potionSO.cost;


    }

    private void Update()
    {

    }
}
