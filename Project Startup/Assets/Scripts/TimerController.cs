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
    
    bool timerGoing;
    private TimeSpan time;
    public float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "5:00";
        BeginTimer();
    }

    private void Update()
    {
        if(elapsedTime <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void BeginTimer() {
        timerGoing = true;
        //elapsedTime = 300f;
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
            elapsedTime -= Time.deltaTime;
            time = TimeSpan.FromSeconds(elapsedTime);
            string timeString = time.ToString("m':'ss");
            timerText.text = timeString;

            yield return null;
        }
    }
}
