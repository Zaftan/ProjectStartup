using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerSpawnBehaviour : MonoBehaviour
{
    public List<Customer> customersOutside;
    public int customersInShop;
    public List<GameObject> potions;

    public List<Transform> customerParents;

    public GameObject customerOrder;

    public GameObject customerPrefab;

    public int randomNumberForSpawn;

    bool once;

    // Start is called before the first frame update
    void Start()
    {
        settingUpCustomer();
        StartCoroutine(spawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void settingUpCustomer()
    {
        if (!once)
        {
            Debug.Log("calling customer in");
            int randomCustomer = Random.Range(0, customersOutside.Count);
            int randomPotion = Random.Range(0, potions.Count);
            customerPrefab.GetComponent<CustomerDisplay>().potionPrefab = potions[randomPotion];
            customerPrefab.GetComponent<CustomerDisplay>().customer = customersOutside[randomCustomer];
            //customerPrefab.GetComponent<CustomerDisplay>().potionSprite = potions[randomPotion].GetComponent<SpriteRenderer>();
            Instantiate(customerPrefab, customerParents[customersInShop]);
            customersInShop++;
        }
    }

    IEnumerator spawnTimer()
    {
        randomNumberForSpawn = Random.Range(0, 101);
        yield return new WaitForSeconds(Random.Range(2, 6));
        if (customersInShop != 3 && randomNumberForSpawn > 50)
        {
            settingUpCustomer();
        }
        StartCoroutine(spawnTimer());
    }
}
