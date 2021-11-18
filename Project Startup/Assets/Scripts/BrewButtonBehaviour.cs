using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewButtonBehaviour : MonoBehaviour
{
    [SerializeField] CauldronBehaviour cauldron;
    public void OnButtonPressed()
    {
        if (compareLists(cauldron.ingredients, cauldron.purplePotion.GetComponent<Potion>().ingredients))
        {
            cauldron.ingredients.Clear();
            Instantiate(cauldron.purplePotion, cauldron.potionPosition);
        }
        else if (compareLists(cauldron.ingredients, cauldron.cyanPotion.GetComponent<Potion>().ingredients))
        {
            cauldron.ingredients.Clear();
            Instantiate(cauldron.cyanPotion, cauldron.potionPosition);
        }
        else if (compareLists(cauldron.ingredients, cauldron.cyanPotion.GetComponent<Potion>().ingredients))
        {
            cauldron.ingredients.Clear();
            Instantiate(cauldron.yellowPotion, cauldron.potionPosition);
        }
        else
        {
            cauldron.ingredients.Clear();
            Debug.Log("No potions with these ingredients could be found.");
        }
    }

    private bool compareLists(List<GameObject> inCauldron, List<GameObject> inPotion)
    {
        if(inCauldron.Count != inPotion.Count) return false;
        
        
        for (int i = inCauldron.Count - 1; i >= 0; i--)
        {
            for (int j = 0; j < inPotion.Count; j++)
            {
                if (inCauldron[i].name == inPotion[j].name)
                {
                    inCauldron.Remove(inCauldron[i]);
                    inPotion.Remove(inPotion[j]);
                    //break;
                }
            }
        }

        Debug.Log("count Cauldron = " + inCauldron.Count + ", count Potion = " + inPotion.Count);

        if (inCauldron.Count == 0 && inPotion.Count == 0)
        {
            return true;
        }
        else return false;
    }
}
