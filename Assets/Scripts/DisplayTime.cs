using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class DisplayTime : MonoBehaviour
{
    public Timer timer;
    public int minutes = 0, seconds = 0;
    public string timeText;
    //public int minute, second;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.minutes != minutes || timer.seconds != seconds)
        {
            minutes = timer.minutes;
            seconds = timer.seconds;
            DisplayTimer();
        }
    }
    void DisplayTimer()
    {
        timeText = string.Format("{0:0}:{1:00}", minutes, seconds);
        GetComponent<UnityEngine.UI.Text>().text = timeText;
    }
}
