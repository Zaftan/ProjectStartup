using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomerSpawnBehaviour : MonoBehaviour
{
    public static CustomerSpawnBehaviour instance;

    //Lists
    public List<Customer> customersOutside;
    public List<PotionSO> potions;
    public List<Transform> customerParents;
    public List<Transform> openPosition = new List<Transform>();
    
    //GameObjects
    public GameObject potionPrefab;
    public GameObject customerPrefab;

    public int randomNumberForSpawn;

    bool once;
    
    

    [Header("ONLY CHANGE THIS WOUTER YOU CUNT")]
    [SerializeField] int minRandomTime;
    [SerializeField] int maxRandomTime;

    [SerializeField] float[] percentagesNoEvent;
    [SerializeField] float[] percentagesDragonAttack;
    [SerializeField] float[] percentagesZombrewAttack;



    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        if (openPosition.Count < 3)
        {
            checkPositions();
        }
        settingUpCustomer();
        StartCoroutine(spawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        if (openPosition.Count < 3)
        {
            checkPositions();
        }
    }

    void checkPositions()
    {
        if(customerParents[0].childCount < 1 && !openPosition.Contains(customerParents[0]))
        {
            openPosition.Add(customerParents[0]);
        }
        if (customerParents[1].childCount < 1 && !openPosition.Contains(customerParents[1]))
        {
            openPosition.Add(customerParents[1]);
        }
        if (customerParents[2].childCount < 1 && !openPosition.Contains(customerParents[2]))
        {
            openPosition.Add(customerParents[2]);
        }
    }

    private void settingUpCustomer()
    {
        if (!once)
        {
            //Get random numbers
            int randomCustomer = Random.Range(0, customersOutside.Count);
            int randomPotion = Random.Range(0, potions.Count);

            //Set variables for the customer
            customerPrefab.GetComponent<CustomerDisplay>().potionPrefab = potionPrefab;
            customerPrefab.GetComponent<CustomerDisplay>().potionSO = potions[potionChance()];
            customerPrefab.GetComponent<CustomerDisplay>().customer = customersOutside[randomCustomer];

            //Instantiate customer and remove from open position list;
            Instantiate(customerPrefab, openPosition[0]);
            openPosition.Remove(openPosition[0]);
        }
    }

    IEnumerator spawnTimer()
    {
        randomNumberForSpawn = Random.Range(0, 101);
        yield return new WaitForSeconds(Random.Range(minRandomTime, maxRandomTime));
        if (openPosition.Count != 0 && randomNumberForSpawn > 50)
        {
            settingUpCustomer();
        }
        if (TimerController.instance.elapsedTime > 0)
        {
            StartCoroutine(spawnTimer());
        }
    }

    int potionChance()
    {
        float random = Random.Range(0f, 1f);
        float total = 0;
        float numberToAdd = 0;

        switch (gameObject.GetComponent<EventBehaviour>().currentEvent)
        {
            case EventBehaviour.Events.noEvent:
                for (int i = 0; i < percentagesNoEvent.Length; i++)
                {
                    total += percentagesNoEvent[i];
                }
                for (int i = 0; i < potions.Count; i++)
                {
                    if (percentagesNoEvent[i] / total + numberToAdd >= random)
                    {
                        return i;
                    }
                    else
                    {
                        numberToAdd += percentagesNoEvent[i] / total;
                    }
                }
                break;

            case EventBehaviour.Events.DragonAttack:
                for (int i = 0; i < percentagesDragonAttack.Length; i++)
                {
                    total += percentagesNoEvent[i];
                }
                for (int i = 0; i < potions.Count; i++)
                {
                    if (percentagesDragonAttack[i] / total + numberToAdd >= random)
                    {
                        return i;
                    }
                    else
                    {
                        numberToAdd += percentagesDragonAttack[i] / total;
                    }
                }
                break;

            case EventBehaviour.Events.zombrewInvasion:
                for (int i = 0; i < percentagesZombrewAttack.Length; i++)
                {
                    total += percentagesZombrewAttack[i];
                }
                for (int i = 0; i < potions.Count; i++)
                {
                    if (percentagesZombrewAttack[i] / total + numberToAdd >= random)
                    {
                        return i;
                    }
                    else
                    {
                        numberToAdd += percentagesZombrewAttack[i] / total;
                    }
                }
                break;
        }
     return 0;
    }
}
