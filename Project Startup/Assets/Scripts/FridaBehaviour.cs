using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridaBehaviour : MonoBehaviour
{
    [SerializeField] List<PotionSO> potions;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        foreach (PotionSO potion in potions)
        {
            if(collision.gameObject.GetComponent<Potion>().potionSO.name == potion.name)
            {
                Destroy(collision.gameObject);
                StartCoroutine(animation());
            }
        }
    }

    private IEnumerator animation()
    {
        animator.SetBool("playEating", true);
        yield return new WaitForSeconds(1.2f);
        animator.SetBool("playEating", false);
    }
}
