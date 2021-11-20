using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerDisplay : MonoBehaviour
{
    public Customer customer;

    public Transform orderParent;
    public SpriteRenderer characterSprite;
    public SpriteRenderer potionSprite;
    public GameObject potionPrefab;

    public GameObject textBubble;

    public bool isCLicked;

    void Start()
    {
        characterSprite.sprite = customer.customerSprite;
        customer.potion = potionPrefab;
        potionSprite = potionPrefab.GetComponent<SpriteRenderer>();

        isCLicked = false;
    }

    private void Update()
    {
        if (!isCLicked)
        {
            characterSprite.color = Color.gray;
            //textBubble.SetActive(false);
        }
        else
        {
            characterSprite.color = Color.white;
            //textBubble.SetActive(true);

        }
    }

    private void OnMouseDown()
    {
        isCLicked = true;
    }
}
