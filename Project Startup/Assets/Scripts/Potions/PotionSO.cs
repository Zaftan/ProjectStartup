using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Potion", menuName = "Potion/potion")]
public class PotionSO : ScriptableObject
{
    public Sprite potionSprite;
    public Sprite bookSprite;
    public new string name;
    public int cost;
    public List<Ingredient> ingredients;
}
