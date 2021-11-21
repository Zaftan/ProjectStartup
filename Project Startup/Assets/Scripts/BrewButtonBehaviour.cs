using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewButtonBehaviour : MonoBehaviour
{
    [SerializeField] CauldronBehaviour cauldron;
    public void OnButtonPressed()
    {
        if (compareLists(cauldron.ingredients, cauldron.potionSO["HealthPotion"].ingredients))
        {
            cauldron.ingredients.Clear();
            cauldron.potionPrefab.GetComponent<Potion>().potionSO = cauldron.potionSO["HealthPotion"];
            Instantiate(cauldron.potionPrefab, cauldron.potionPosition);
        }
        else if (compareLists(cauldron.ingredients, cauldron.potionSO["ShieldPotion"].ingredients))
        {
            cauldron.ingredients.Clear();
            cauldron.potionPrefab.GetComponent<Potion>().potionSO = cauldron.potionSO["ShieldPotion"];
            Instantiate(cauldron.potionPrefab, cauldron.potionPosition);
        }
        else if (compareLists(cauldron.ingredients, cauldron.potionSO["ManaPotion"].ingredients))
        {
            cauldron.ingredients.Clear();
            cauldron.potionPrefab.GetComponent<Potion>().potionSO = cauldron.potionSO["ManaPotion"];
            Instantiate(cauldron.potionPrefab, cauldron.potionPosition);
        }
        else
        {
            cauldron.ingredients.Clear();
            Debug.Log("No potions with these ingredients could be found.");
        }
    }

    private bool compareLists(List<GameObject> tempInCauldron, List<GameObject> tempInPotion)
    {
        List<GameObject> inCauldron = new List<GameObject>(tempInCauldron);
        List<GameObject> inPotion = new List<GameObject>(tempInPotion);

        if (inCauldron.Count != inPotion.Count) return false;
        
        
        for (int i = inCauldron.Count - 1; i >= 0; i--)
        {
            for (int j = 0; j < inPotion.Count; j++)
            {
                if (inCauldron[i].name == inPotion[j].name)
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
