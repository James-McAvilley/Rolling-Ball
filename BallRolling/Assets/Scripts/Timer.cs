using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    float seconds = 0;
    int minutes = 0;
    float overallSeconds;
    int overallMinutes;
    
    //Keeps timer running consistently throughout the game
    void Awake()
    {
        GameObject[] GameTimer = GameObject.FindGameObjectsWithTag("Timer");
        if (GameTimer.Length > 1)
            Destroy(this.gameObject);

        DontDestroyOnLoad(transform.root.gameObject);
    }
    
    void Start()
    {
        
    }

    // Continuously updates the UI element for the timer
    void Update()
    {
        TimerUI();
        TimerText.text = minutes + ":" + ((int)seconds).ToString("00");

    }

    //Tracks seconds elapsed and converts it into minutes/seconds format
    public void TimerUI()
    {
        if (SceneManager.GetActiveScene().buildIndex != 5)
        {
            seconds += Time.deltaTime;
            
            if (seconds >= 60)
            {
                minutes++;
                seconds = 0;
            }
            
        }

        
    }
}
