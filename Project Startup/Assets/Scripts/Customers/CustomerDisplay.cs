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

    public bool Once;
    bool onObject;
    bool wasClicked;

    Vector3 textBubbleScaleNormal;
    Vector3 textBubbleBigPosition;
    [SerializeField] Vector3 textBubbleSmallPosition;

    void Start()
    {
        characterSprite.sprite = customer.customerSprite;
        characterSprite.transform.position += customer.spriteOffset;
        customer.potion = potionPrefab;

        potionSpriteRenderer.sprite = potionSO.potionSprite;

        characterSprite.color = Color.gray;
        textBubble.SetActive(false);

        Once = false;
        textBubbleScaleNormal = textBubble.transform.localScale;
        textBubbleBigPosition = textBubble.transform.position;
    }

    private void Update()
    {
        if (onObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                characterSprite.color = Color.white;
                textBubble.transform.localScale = textBubbleScaleNormal;
                textBubble.transform.position = textBubbleBigPosition;
                wasClicked = true;
                textBubble.SetActive(true);
                Once = true;
            }
        }
        else if (wasClicked && !onObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                characterSprite.color = Color.gray;
                if (Once)
                {
                    textBubble.transform.position -= textBubbleSmallPosition;
                    textBubble.transform.localScale *= 0.5f;
                    Once = false;
                }
            }
        } 
        else if(!onObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                characterSprite.color = Color.gray;
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