using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public int money;

    [SerializeField] Text ballanceText;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);   
    }

    // Update is called once per frame
    void Update()
    {
        ballanceText.text = money.ToString();
    }

    public void Sell(int moneyToAdd) {
        money += moneyToAdd;
    }

    public void Buy(int moneyToRemove)
    {
        money -= moneyToRemove;
    }



}
