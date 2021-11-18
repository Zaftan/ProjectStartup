using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PotionBase
{
    
    List<GameObject> ingredients;
    Sprite sprite;

    public abstract void brew();
}
