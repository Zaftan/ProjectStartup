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
    public float elapsedTime;

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
        BeginTimer();
    }

    private void Update()
    {
        dayText.text = "Day " + PlayerData.instance.currentDay;
        if(elapsedTime >= 1020 && CustomerSpawnBehaviour.instance.openPosition.Count == 3)
        {
            SceneManager.LoadScene(1);
        }
        else if (elapsedTime >= 1020 && CustomerSpawnBehaviour.instance.openPosition.Count != 3)
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
            time = TimeSpan.FromSeconds(elapsedTime);
            string timeString = time.ToString("mm':'ss");
            timerText.text = timeString;

            yield return null;
        }
    }

    private IEnumerator updateTime()
    {
        yield return new WaitForSeconds(5);
        elapsedTime += 10;
        StartCoroutine(updateTime());
    }
}
