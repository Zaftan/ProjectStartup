using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventBehaviour : MonoBehaviour
{
    public static EventBehaviour instance;

    [HideInInspector] public enum Events { noEvent = 0, DragonAttack, zombrewInvasion};

    public float[] percentagesForEventsTop;


    public Events currentEvent;
    [SerializeField] Text currentEventText;
    [SerializeField] Text currentEventDescriptionText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        } else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        currentEvent = Events.noEvent;
    }

    private void Update()
    {
        if(currentEventText == null)
        {
            currentEventText = GameObject.FindGameObjectWithTag("EventNameText").GetComponent<Text>();
        }
        if(currentEventDescriptionText == null)
        {
            currentEventDescriptionText = GameObject.FindGameObjectWithTag("EventDescriptionText").GetComponent<Text>();
        }
        if (currentEventText != null)
        {
            switch (currentEvent)
            {
                case Events.noEvent:
                    currentEventText.text = "No Event";
                    break;

                case Events.DragonAttack:
                    currentEventText.text = "Dragon Attack";
                    break;

                case Events.zombrewInvasion:
                    currentEventText.text = "Zombrew Invasion";
                    break;
            }
        }
        if(currentEventDescriptionText != null)
        {
            switch (currentEvent)
            {
                case Events.noEvent:
                    currentEventDescriptionText.text = "No special potions are being requested more often";
                    break;

                case Events.DragonAttack:
                    currentEventDescriptionText.text = "Health Potions will be requested more often";
                    break;

                case Events.zombrewInvasion:
                    currentEventDescriptionText.text = "Shield Potions will be requested more often";
                    break;
            }
        }
    }

    public void getRandomEvent()
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
    }
}
