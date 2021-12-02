using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrewButtonBehaviour : MonoBehaviour
{
    [SerializeField] CauldronBehaviour cauldron;

    public List<Transform> potionParents;
    public List<Transform> openPosition = new List<Transform>();

    private void Update()
    {
        if (openPosition.Count < 3)
        {
            checkPositions();
        }
    }

    void checkPositions()
    {
        if (potionParents[0].childCount < 1 && !openPosition.Contains(potionParents[0]))
        {
            openPosition.Add(potionParents[0]);
        }
        if (potionParents[1].childCount < 1 && !openPosition.Contains(potionParents[1]))
        {
            openPosition.Add(potionParents[1]);
        }
        if (potionParents[2].childCount < 1 && !openPosition.Contains(potionParents[2]))
        {
            openPosition.Add(potionParents[2]);
        }
    }

    public void OnButtonPressed()
    {
        if (openPosition.Count > 0)
        {
            if (compareLists(cauldron.ingredientsInCauld, cauldron.potionSO["HealthPotion"].ingredients))
            {
                PlacePotion(cauldron.potionSO["HealthPotion"]);
            }
            else if (compareLists(cauldron.ingredientsInCauld, cauldron.potionSO["ShieldPotion"].ingredients))
            {
                PlacePotion(cauldron.potionSO["ShieldPotion"]);
            }
            else if (compareLists(cauldron.ingredientsInCauld, cauldron.potionSO["ManaPotion"].ingredients))
            {
                PlacePotion(cauldron.potionSO["ManaPotion"]);
            }
            else if (compareLists(cauldron.ingredientsInCauld, cauldron.potionSO["FireResistance"].ingredients))
            {
                PlacePotion(cauldron.potionSO["FireResistance"]);
            }
            else if (compareLists(cauldron.ingredientsInCauld, cauldron.potionSO["Invisibility"].ingredients))
            {
                PlacePotion(cauldron.potionSO["Invisibility"]);
            }
            else if (cauldron.ingredientsInCauld.Count == 0)
            {
                Debug.Log("No ingredients where placed in te cauldron");
            }
            else
            {
                PlacePoison();
            }
        }
        else
        {
            Debug.Log("You can not make any potions. The counter is full");
        }
    }

    private void PlacePoison()
    {
        cauldron.ingredientsInCauld.Clear();
        cauldron.potionPrefab.GetComponent<Potion>().potionSO = cauldron.potionSO["Poison"];
        Instantiate(cauldron.potionPrefab, openPosition[0]);
        openPosition.Remove(openPosition[0]);
        StartCoroutine(cauldron.playAnimation("poisonAnim"));
    }

    private void PlacePotion(PotionSO potion)
    {
        cauldron.ingredientsInCauld.Clear();
        cauldron.potionPrefab.GetComponent<Potion>().potionSO = potion;
        Instantiate(cauldron.potionPrefab, openPosition[0]);
        openPosition.Remove(openPosition[0]);
        StartCoroutine(cauldron.playAnimation("smokeAnim"));
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
