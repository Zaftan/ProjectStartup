using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerData : MonoBehaviour
{
    public int money;

    [SerializeField] GameObject ballanceText;

    public static PlayerData instance;

    public Dictionary<string, int> ingredientAmounts = new Dictionary<string, int>();

    public int currentDay = 1;

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

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        ballanceText = GameObject.FindGameObjectWithTag("MoneyText");
    }

    // Update is called once per frame
    void Update()
    {
        if(ballanceText == null)
        {
            ballanceText = GameObject.FindGameObjectWithTag("MoneyText");
        }
        if (ballanceText != null)
        {
            ballanceText.GetComponent<Text>().text = money.ToString();
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
