using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject redIng;
    [SerializeField] GameObject blueIng;
    [SerializeField] GameObject greenIng;

    [SerializeField] GameObject cauldron;
    private void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null)
            {
                if (hit.collider == redIng.GetComponent<BoxCollider2D>())
                {
                    Debug.Log("Red ingredient");
                }
                if (hit.collider == blueIng.GetComponent<BoxCollider2D>())
                {
                    Debug.Log("blue ingredient");
                }
                if (hit.collider == greenIng.GetComponent<BoxCollider2D>())
                {
                    Debug.Log("green ingredient");
                }
                if (hit.collider == cauldron.GetComponent<BoxCollider2D>())
                {
                    Debug.Log("cauldron");
                }
            }
        }*/
    }
}
