using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private GameObject ttimer;
    private Timer timer;
    private int pause;
    public StatManager statManager;
    [System.NonSerialized] 
    public float maxHp;
    [System.NonSerialized]
    public float hp;
    // Start is called before the first frame update
    void Start()
    {
        ttimer = GameObject.Find("Timer");
        timer=ttimer.GetComponent<Timer>();
        maxHp= statManager.maxHp;
        hp = maxHp;
        statManager.hp= hp;
    }

    public void Death()
    {
        print("Dead");
        //timer.pause = 0;
        Time.timeScale = 1;
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins", 0) + statManager.coins);
        
        Destroy(gameObject);
        SceneManager.LoadScene(0);
    }
    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        statManager.hp = hp;
        //print("PllayerHP:" + hp);
        if (hp <= 0) Death();
    }
}
