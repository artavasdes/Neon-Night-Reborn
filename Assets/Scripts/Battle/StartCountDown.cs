using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class StartCountDown : MonoBehaviour
{
    
    public TextMeshProUGUI countDown;
    public bool start = false; 
    public float TimeLeft = 3; 

    // Start is called before the first frame update
    void Start()
    {
        start = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            if (TimeLeft > 1)
            {
                updateCount(TimeLeft - 1);
                TimeLeft -= Time.deltaTime; 
            }
            else{ 
                TimeLeft -= Time.deltaTime; 
                // TimeLeft = 0;
                countDown.text = "Fight!"; 
            }
    }

    void updateCount(float currentTime)
    {
        currentTime -= 1; 
        
        countDown.text = currentTime.ToString("N0");
    }
    }
}

