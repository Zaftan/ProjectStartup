using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBook : MonoBehaviour
{

    public Button openBook, nextButton, previousButton, closeBook;
    public GameObject recipeBook;

    public Text potionName;
    public Image ingredient1, ingredient2, ingredient3, potionImage;

    public PotionSO[] potion;

    private int currentPage = 0;
    private int recipeCounter = -1;

    public void Start()
    {
        foreach(PotionSO potion in potion)
        {
            recipeCounter++;
        }
    }

    public void Update()
    {
        if (currentPage >= recipeCounter)
        {
            nextButton.gameObject.SetActive(false);
        }
        else if(currentPage <= 0)
        {
            previousButton.gameObject.SetActive(false);
        }
        else
        {
            nextButton.gameObject.SetActive(true);
            previousButton.gameObject.SetActive(true);
        }
    }

    public void OpenRecipeBook()
    {
        recipeBook.SetActive(true);
        openBook.gameObject.SetActive(false);
        FillPage(potion[currentPage]);
    }

    public void NextPage()
    {
        currentPage++;
        FillPage(potion[currentPage]);
    }

    public void PreviousPage()
    {
        currentPage--;
        FillPage(potion[currentPage]);
    }

    public void CloseRecipeBook()
    {
        recipeBook.SetActive(false);
        openBook.gameObject.SetActive(true);
    }

    void FillPage(PotionSO potion)
    {
        Ingredient ingredient;

        if (potion.ingredients.Count == 2)
        {
            potionName.text = potion.name;

            ingredient2.gameObject.transform.localPosition = new Vector3(40.3f, -88.1f, 0.0f);

            ingredient = potion.ingredients[0];
            ingredient1.sprite = ingredient.bookSprite;
            ingredient = potion.ingredients[1];
            ingredient2.sprite = ingredient.bookSprite;
            ingredient3.gameObject.SetActive(false);

            potionImage.sprite = potion.bookSprite;
        }

        if (potion.ingredients.Count == 3)
        {
            potionName.text = potion.name;

            ingredient2.gameObject.transform.localPosition = new Vector3(26.6f, -88.1f, 0.0f);

            ingredient = potion.ingredients[0];
            ingredient1.sprite = ingredient.bookSprite;
            ingredient = potion.ingredients[1];
            ingredient2.sprite = ingredient.bookSprite;
            ingredient = potion.ingredients[2];
            ingredient3.sprite = ingredient.bookSprite;

            ingredient3.gameObject.SetActive(true);

            potionImage.sprite = potion.bookSprite;
        }
    }
}
