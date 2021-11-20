using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCounter : MonoBehaviour
{
    [SerializeField] bool isOpen;
    [SerializeField] bool opened;

    [SerializeField] GameObject brewButton;

    private void Start()
    {
        isOpen = false;
    }

    private void Update()
    {

        /*if(Input.GetMouseButtonDown(0) && Input.mousePosition.y < 60 && !isOpen)
        {
            isOpen = true;
            brewButton.SetActive(true);
        } 
        
        if (Input.GetMouseButtonDown(0) && Input.mousePosition.y > 163 && isOpen)
        {
            isOpen = false;
            opened = false;
            brewButton.SetActive(false);
        }

        if (isOpen && !opened)
        {

            Vector3 position = Camera.main.transform.position;
            position.y = (position.y - 2);
            Camera.main.transform.position = position;
            opened = true;
        }
        else if (isOpen && opened) { }
        else
        {
            Vector3 position = Camera.main.transform.position;
            position.y = 0;
            Camera.main.transform.position = position;
        }*/
    }
}
