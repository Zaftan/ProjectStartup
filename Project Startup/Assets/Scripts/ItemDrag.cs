using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrag : MonoBehaviour
{
    bool dragging;
    public bool hasPickedUp = false;

    private void OnMouseDown()
    {
        dragging = true;
        hasPickedUp = true;
    }

    private void OnMouseUp()
    {
        dragging = false;
    }

    private void Update()
    {
        if (dragging)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePos);
        }
        if (!dragging)
        {
            StartCoroutine(resetPos());
        }
    }

    private IEnumerator resetPos()
    {
        yield return new WaitForSeconds(0.1f);
        transform.position = transform.parent.position;

    }
}
