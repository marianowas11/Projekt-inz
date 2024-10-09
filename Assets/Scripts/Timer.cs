using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 0;
    public int pause = 1;//0 for stop
    public int minutes, seconds;
    
    //public int minute, second;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= 0 && pause==1)
        {//oblicza czas od rozpoczêcia gry
            timer += Time.deltaTime;
            DisplayTime();
        }
        else
        {
            print("paused");
        }
    }
    public void DisplayTime()
    {//zmienia czasu z zmienno przecinowego
     //na dok³adne minuty i sekundy
        minutes = Mathf.FloorToInt(timer / 60);
        seconds = Mathf.FloorToInt(timer % 60);
    }
}
