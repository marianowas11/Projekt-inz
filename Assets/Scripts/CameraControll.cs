using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private GameObject ttimer;
    private Timer timer;
    private int pause=1;

    void Start()
    {
        ttimer = GameObject.Find("Timer");
        timer=ttimer.GetComponent<Timer>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        pause = timer.pause;
        if(pause==1)transform.position = player.transform.position + new Vector3(0,0,-1);
    }
}
