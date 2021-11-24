using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronBehaviour : MonoBehaviour
{
    public List<Ingredient> ingredientsSO;

    public List<Ingredient> ingredientsInCauld;

    [Header("Totaly a dictionary what are you talking about")]
    [SerializeField] List<string> potionNames;
    [SerializeField] List<PotionSO> potionList;
    public Dictionary<string, PotionSO> potionSO = new Dictionary<string, PotionSO>();

    public GameObject potionPrefab;

    public Transform potionPosition;
    
    [SerializeField] Transform fruitPosition;
    [SerializeField] Transform flowerPosition;
    [SerializeField] Transform fungusPosition;
    [SerializeField] Transform powderPosition;

    public static CauldronBehaviour instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    private void Start()
    {
        for (int i = 0; i < potionList.Count; i++)
        {
            potionSO.Add(potionNames[i], potionList[i]);
        }
    }

    Vector3 settingUpPositions(Transform position)
    {
        Vector3 pos = position.transform.position;
        pos.z = -5;
        return pos;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<IngredientDisplayBrew>().ingredient == ingredientsSO[0] && Input.GetMouseButton(0) == false)
        {
            ingredientsInCauld.Add(ingredientsSO[0]);
            collision.gameObject.transform.position = settingUpPositions(fruitPosition);
            PlayerData.instance.UseIngredient(ingredientsSO[0].ingredientName, 1);
        }
        if (collision.gameObject.GetComponent<IngredientDisplayBrew>().ingredient == ingredientsSO[1] && Input.GetMouseButton(0) == false)
        {
            ingredientsInCauld.Add(ingredientsSO[1]);
            collision.gameObject.transform.position = settingUpPositions(flowerPosition);
            PlayerData.instance.UseIngredient(ingredientsSO[1].ingredientName, 1);
        }
        if (collision.gameObject.GetComponent<IngredientDisplayBrew>().ingredient == ingredientsSO[2] && Input.GetMouseButton(0) == false)
        {
            ingredientsInCauld.Add(ingredientsSO[2]);
            collision.gameObject.transform.position = settingUpPositions(fungusPosition);
            PlayerData.instance.UseIngredient(ingredientsSO[2].ingredientName, 1);
        }
        if (collision.gameObject.GetComponent<IngredientDisplayBrew>().ingredient == ingredientsSO[3] && Input.GetMouseButton(0) == false)
        {
            ingredientsInCauld.Add(ingredientsSO[3]);
            collision.gameObject.transform.position = settingUpPositions(powderPosition);
            PlayerData.instance.UseIngredient(ingredientsSO[3].ingredientName, 1);
        }
    }
}
