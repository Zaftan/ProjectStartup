using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerData : MonoBehaviour
{
    public int money;

    GameObject ballanceText;
    GameObject fruitText;
    GameObject flowerText;
    GameObject fungusText;
    GameObject powderText;

    public static PlayerData instance;

    public Dictionary<string, int> ingredientAmounts = new Dictionary<string, int>();

    public int currentDay = 1;

    //setting up cursor
    public Texture2D cursorTextureIdle;
    public Texture2D cursorTextureGrab;
    public Texture2D cursorTextureHover;

    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this);
        }
        else { 
            instance = this;
            if (ingredientAmounts.Count == 0)
            {
                ingredientAmounts.Add("Fruit", 10);
                ingredientAmounts.Add("Flower", 10);
                ingredientAmounts.Add("Fungus", 10);
                ingredientAmounts.Add("Powder", 10);
            }
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        ballanceText = GameObject.FindGameObjectWithTag("MoneyText");
    }

    void Update()
    {
        SetupBalanceText();
        SetupIngredientsText();

        if (Input.GetMouseButton(0))
        {
            Cursor.SetCursor(cursorTextureGrab, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(cursorTextureIdle, hotSpot, cursorMode);
        }
    }

    private void SetupBalanceText()
    {
        if (ballanceText == null)
        {
            ballanceText = GameObject.FindGameObjectWithTag("MoneyText");
        }
        if (ballanceText != null)
        {
            ballanceText.GetComponent<Text>().text = money.ToString();
        }
    }

    private void SetupIngredientsText()
    {
        if (fruitText == null)
        {
            fruitText = GameObject.FindGameObjectWithTag("FruitText");
            flowerText = GameObject.FindGameObjectWithTag("FlowerText");
            fungusText = GameObject.FindGameObjectWithTag("FungusText");
            powderText = GameObject.FindGameObjectWithTag("PowderText");
        }
        if (fruitText.GetComponent<Text>() != null)
        {
            fruitText.GetComponent<Text>().text = ingredientAmounts["Fruit"].ToString();
            flowerText.GetComponent<Text>().text = ingredientAmounts["Flower"].ToString();
            fungusText.GetComponent<Text>().text = ingredientAmounts["Fungus"].ToString();
            powderText.GetComponent<Text>().text = ingredientAmounts["Powder"].ToString();
        }
        if (fruitText.GetComponent<TextMesh>() != null)
        {
            fruitText.GetComponent<TextMesh>().text = ingredientAmounts["Fruit"].ToString();
            flowerText.GetComponent<TextMesh>().text = ingredientAmounts["Flower"].ToString();
            fungusText.GetComponent<TextMesh>().text = ingredientAmounts["Fungus"].ToString();
            powderText.GetComponent<TextMesh>().text = ingredientAmounts["Powder"].ToString();
        }
    }

    public void Sell(int moneyToAdd) {
        money += moneyToAdd;
    }

    public void Buy(int moneyToRemove)
    {
        money -= moneyToRemove;
    }

    public void UseIngredient(string ingredientName, int numberOfUsedIngredients)
    {
        ingredientAmounts[ingredientName] -= numberOfUsedIngredients;
    }

    public void buyIngredient(string ingredientName, int numberOfBoughtIngredients)
    {
        ingredientAmounts[ingredientName] += numberOfBoughtIngredients;
    }
}
