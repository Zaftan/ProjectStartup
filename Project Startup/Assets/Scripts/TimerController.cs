using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public Text timerText;
    public Text dayText;
    
    bool timerGoing;
    private TimeSpan time;
    float startTime;

    public float gameTimeInMinutes;
    public float currentGameTime;

    float secondsFor10Minutes;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //timerText.text = "5:00";
        startTime = 540;
        secondsFor10Minutes = ((gameTimeInMinutes * 60) / 8) / 6;

        BeginTimer();
    }

    private void Update()
    {
        dayText.text = "Day " + PlayerData.instance.currentDay;
        if(currentGameTime >= gameTimeInMinutes * 60 && CustomerSpawnBehaviour.instance.openPosition.Count == 3)
        {
            SceneManager.LoadScene(1);
        }
        else if (currentGameTime >= (gameTimeInMinutes * 60) + 1  && CustomerSpawnBehaviour.instance.openPosition.Count != 3)
        {
            EndTimer();
        }
    }

    public void BeginTimer() {
        timerGoing = true;
        StartCoroutine(updateTime());
        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            time = TimeSpan.FromSeconds(startTime);
            string timeString = time.ToString("mm':'ss");
            timerText.text = timeString;

            yield return null;
        }
    }

    private IEnumerator updateTime()
    {
        yield return new WaitForSeconds(secondsFor10Minutes);
        startTime += 10;
        currentGameTime += secondsFor10Minutes;
        StartCoroutine(updateTime());
    }
}
