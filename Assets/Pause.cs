using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                print(pauseMenu);
                Time.timeScale = 0;
                print(Time.timeScale);
                pauseMenu.SetActive(true);
            }
            else if (Time.timeScale == 0)
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }

    }
    
}
