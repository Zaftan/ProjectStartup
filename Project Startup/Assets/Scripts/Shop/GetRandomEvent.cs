using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomEvent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventBehaviour.instance.getRandomEvent();
    }
}
