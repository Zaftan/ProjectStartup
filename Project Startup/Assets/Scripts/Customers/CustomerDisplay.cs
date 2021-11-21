using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerDisplay : MonoBehaviour
{
    public Customer customer;

    public Transform orderParent;
    public SpriteRenderer characterSprite;

    public SpriteRenderer potionSpriteRenderer;

    public GameObject potionPrefab;
    public PotionSO potionSO;

    public GameObject textBubble;

    public bool isClicked;
    bool onObject;

    void Start()
    {

        characterSprite.sprite = customer.customerSprite;
        characterSprite.transform.position += customer.spriteOffset;
        customer.potion = potionPrefab;

        potionSpriteRenderer.sprite = potionSO.potionSprite;

        characterSprite.color = Color.gray;
        textBubble.SetActive(false);

        isClicked = false;
    }

    private void Update()
    {
        if (onObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                characterSprite.color = Color.white;
                textBubble.SetActive(true);
            }
        }
        else if(!onObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                characterSprite.color = Color.gray;
                textBubble.SetActive(false);
            }

        }
    }
    void OnMouseEnter()
    {
        onObject = true;
    }

    private void OnMouseExit()
    {
        onObject = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Potion>().potionSO.name == potionSO.name && !Input.GetMouseButton(0) && collision.gameObject.GetComponent<ItemDrag>().hasPickedUp)
        {
            Destroy(collision.gameObject);
            StartCoroutine(GotPotion());
        }
    }

    IEnumerator GotPotion()
    {
        characterSprite.sprite = customer.customerSpriteHappy;
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
