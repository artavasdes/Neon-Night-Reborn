using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{

    public static float TimeLeft = 99.0F;
    public static bool TimerOn = false;
    public static bool GameOver = false;

    public TextMeshProUGUI TimerText;
    // void Start()
    // {
    //     TimerOn = true;
    // }

    // Update is called once per frame
    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                updateTimer(TimeLeft);
                TimeLeft -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time is Up!");
                TimeLeft = 0;
                TimerOn = false;
                GameOver = true;
                SceneManager.LoadScene("MainMenu");
            }
        }
    }

    void updateTimer(float currentTime)
    {
        currentTime -= 1;

        TimerText.text = currentTime.ToString("N0");
    }

}
