using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronBehaviour : MonoBehaviour
{
    public GameObject red;
    public GameObject green;
    public GameObject blue;

    public List<GameObject> ingredients;

    [SerializeField] List<string> potionNames;
    [SerializeField] List<PotionSO> potionList;

    public Dictionary<string, PotionSO> potionSO = new Dictionary<string, PotionSO>();

    public GameObject potionPrefab;

    public Transform potionPosition;
    
    [SerializeField] Transform redPosition;
    [SerializeField] Transform greenPosition;
    [SerializeField] Transform bluePosition;

    private void Start()
    {
        for (int i = 0; i < potionList.Count; i++)
        {
            potionSO.Add(potionNames[i], potionList[i]);
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
