using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToAdd : MonoBehaviour
{
    // Update is called once per frame

    private void OnMouseDown()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            CauldronBehaviour.instance.ingredientsInCauld.Add(GetComponent<IngredientDisplayBrew>().ingredient);
        }
    }
}
