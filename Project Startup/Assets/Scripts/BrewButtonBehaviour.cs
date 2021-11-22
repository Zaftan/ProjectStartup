using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewButtonBehaviour : MonoBehaviour
{
    [SerializeField] CauldronBehaviour cauldron;
    public void OnButtonPressed()
    {
        if (compareLists(cauldron.ingredientsInCauld, cauldron.potionSO["HealthPotion"].ingredients))
        {
            cauldron.ingredientsInCauld.Clear();
            cauldron.potionPrefab.GetComponent<Potion>().potionSO = cauldron.potionSO["HealthPotion"];
            Instantiate(cauldron.potionPrefab, cauldron.potionPosition);
        }
        else if (compareLists(cauldron.ingredientsInCauld, cauldron.potionSO["ShieldPotion"].ingredients))
        {
            cauldron.ingredientsInCauld.Clear();
            cauldron.potionPrefab.GetComponent<Potion>().potionSO = cauldron.potionSO["ShieldPotion"];
            Instantiate(cauldron.potionPrefab, cauldron.potionPosition);
        }
        else if (compareLists(cauldron.ingredientsInCauld, cauldron.potionSO["ManaPotion"].ingredients))
        {
            cauldron.ingredientsInCauld.Clear();
            cauldron.potionPrefab.GetComponent<Potion>().potionSO = cauldron.potionSO["ManaPotion"];
            Instantiate(cauldron.potionPrefab, cauldron.potionPosition);
        }
        else
        {
            cauldron.ingredientsInCauld.Clear();
            Debug.Log("No potions with these ingredients could be found.");
        }
    }

    private bool compareLists(List<Ingredient> tempInCauldron, List<Ingredient> tempInPotion)
    {
        List<Ingredient> inCauldron = new List<Ingredient>(tempInCauldron);
        List<Ingredient> inPotion = new List<Ingredient>(tempInPotion);

        if (inCauldron.Count != inPotion.Count) return false;
        
        
        for (int i = inCauldron.Count - 1; i >= 0; i--)
        {
            for (int j = 0; j < inPotion.Count; j++)
            {
                if (inCauldron[i].ingredientName == inPotion[j].ingredientName)
                {
                    inCauldron.Remove(inCauldron[i]);
                    inPotion.Remove(inPotion[j]);
                    j = inPotion.Count;
                }
            }
        }

        if (inCauldron.Count == 0 && inPotion.Count == 0)
        {
            return true;
        }
        else return false;
    }
}
