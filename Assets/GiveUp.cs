using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveUp : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth health;
    public Button bt;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.Find("player");
        //health = GetComponent<PlayerHealth>();
        bt.onClick.AddListener(GiveUpLife);
    }

    // Update is called once per frame
    void Update()
    {
        bt.onClick.AddListener(GiveUpLife);
    }
    public void GiveUpLife()
    {
        health.Death();
    }
}
