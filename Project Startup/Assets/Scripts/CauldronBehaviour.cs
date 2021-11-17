using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronBehaviour : MonoBehaviour
{
    [SerializeField] GameObject red;
    [SerializeField] GameObject green;
    [SerializeField] GameObject blue;

    [SerializeField] List<GameObject> ingredients;
    [SerializeField] List<GameObject> potions;

    [SerializeField] Transform potionPosition;

    // Update is called once per frame
    void Update()
    {
        if(ingredients.Contains(red) && ingredients.Contains(blue))
        {
            ingredients.RemoveRange(0, 2);
            Instantiate(potions[0], potionPosition);
        }
        if (ingredients.Contains(green) && ingredients.Contains(blue))
        {
            ingredients.RemoveRange(0, 2);
            Instantiate(potions[1], potionPosition);
        }
        if (ingredients.Contains(red) && ingredients.Contains(green))
        {
            ingredients.RemoveRange(0, 2);
            Instantiate(potions[2], potionPosition);
        }
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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Cauldron colliding with " + other.gameObject.name);
        if (Input.GetMouseButtonUp(0) && other.gameObject == red)
        {
            ingredients.Add(red);
            Destroy(other.gameObject);
        }
        if (Input.GetMouseButtonUp(0) && other.gameObject == blue)
        {
            ingredients.Add(red);
            Destroy(other.gameObject);
        }
        if (Input.GetMouseButtonUp(0) && other.gameObject == green)
        {
            ingredients.Add(red);
            Destroy(other.gameObject);
        }
    }
}
