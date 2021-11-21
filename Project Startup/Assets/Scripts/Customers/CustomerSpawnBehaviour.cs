using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawnBehaviour : MonoBehaviour
{
    public List<Customer> customersOutside;
    public List<PotionSO> potions;
    public GameObject potionPrefab;

    public List<Transform> customerParents;

    public GameObject customerOrder;

    public GameObject customerPrefab;

    public int randomNumberForSpawn;

    [SerializeField] List<Transform> openPosition = new List<Transform>();

    bool once;

    // Start is called before the first frame update
    void Start()
    {
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
            Debug.Log("calling customer in");

            //Get random numbers
            int randomCustomer = Random.Range(0, customersOutside.Count);
            int randomPotion = Random.Range(0, potions.Count);

            //Set variables for the customer
            customerPrefab.GetComponent<CustomerDisplay>().potionPrefab = potionPrefab;
            customerPrefab.GetComponent<CustomerDisplay>().potionSO = potions[randomPotion];
            customerPrefab.GetComponent<CustomerDisplay>().customer = customersOutside[randomCustomer];

            //Instantiate customer and remove from open position list;
            Instantiate(customerPrefab, openPosition[0]);
            openPosition.Remove(openPosition[0]);
        }
    }

    IEnumerator spawnTimer()
    {
        randomNumberForSpawn = Random.Range(0, 101);
        yield return new WaitForSeconds(Random.Range(2, 6));
        if (openPosition.Count != 0 && randomNumberForSpawn > 50)
        {
            settingUpCustomer();
        }
        StartCoroutine(spawnTimer());
    }
}
