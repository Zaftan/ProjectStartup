using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronBehaviour : MonoBehaviour
{
    public GameObject red;
    public GameObject green;
    public GameObject blue;

    public List<GameObject> ingredients;
    //public Dictionary<string, GameObject> potions;

    public GameObject purplePotion;
    public GameObject yellowPotion;
    public GameObject cyanPotion;

    public Transform potionPosition;
    
    [SerializeField] Transform redPosition;
    [SerializeField] Transform greenPosition;
    [SerializeField] Transform bluePosition;

    private void Start()
    {
       /* potions["Purple"] = purplePotion;
        potions["Yellow"] = yellowPotion;
        potions["Cyan"] = cyanPotion;*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Cauldron colliding with " + collision.gameObject.name);
        if(Input.GetMouseButtonUp(0) && collision.gameObject == red)
        {
            ingredients.Add(red);
            Destroy(collision.gameObject);
        }
        if (Input.GetMouseButtonUp(0) && collision.gameObject == blue)
        {
            ingredients.Add(red);
            Destroy(collision.gameObject);
        }
        if (Input.GetMouseButtonUp(0) && collision.gameObject == green)
        {
            ingredients.Add(red);
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == red.name && Input.GetMouseButton(0) == false)
        {
            ingredients.Add(red);
            collision.gameObject.transform.position = redPosition.position;
        }
        if (collision.gameObject.name == blue.name && Input.GetMouseButton(0) == false)
        {
            ingredients.Add(blue);
            collision.gameObject.transform.position = bluePosition.position;
        }
        if (collision.gameObject.name == green.name && Input.GetMouseButton(0) == false)
        {
            ingredients.Add(green);
            collision.gameObject.transform.position = greenPosition.position;
        }
    }
}
