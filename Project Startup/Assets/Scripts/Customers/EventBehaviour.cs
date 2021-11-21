using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventBehaviour : MonoBehaviour
{
    [HideInInspector] public enum Events { noEvent = 0, DragonAttack, zombrewInvasion};

    public float[] percentagesForEventsTop;


    public Events currentEvent;
    [SerializeField] Text currentEventText;

    private void Start()
    {
        int randomNumber = Random.Range(0,101);
        if(randomNumber < percentagesForEventsTop[0])
        {
            currentEvent = Events.noEvent;
        }
        if(randomNumber > percentagesForEventsTop[0] && randomNumber < percentagesForEventsTop[1])
        {
            currentEvent = Events.DragonAttack;
        }
        if (randomNumber > percentagesForEventsTop[1] && randomNumber < percentagesForEventsTop[2])
        {
            currentEvent = Events.zombrewInvasion;
        }

        currentEventText.text = currentEvent.ToString();
    }
}
