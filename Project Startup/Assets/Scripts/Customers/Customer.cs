using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Customer", menuName = "Customer/Customer")]
public class Customer : ScriptableObject
{
    public Sprite customerSprite;
    public Sprite customerSpriteHappy;
    public Sprite customerSpriteAngry;
    public Sprite potionSprite;
    public Transform orderParent;

    public GameObject potion;

    public Vector3 spriteOffset;
}
