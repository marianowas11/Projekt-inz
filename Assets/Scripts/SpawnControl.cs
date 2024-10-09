using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Schema;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    int random;
    public GameObject goblin2;
    public GameObject ghoul;
    public GameObject fly;
    public GameObject slime;
    public GameObject redSlime;
    public GameObject skeleton;
    public GameObject imp;
    public GameObject reaper;
    //public bool enemieSpawn=false;
    GameObject enemieParent;
    public int enemieCount = 0;
    public int enemieMax=15;
    public float enemieSpawnInterval = 1f; //in seconds
    public float enemieSpawnPause = 0.07f;
    public string enemieName ="ghoul";
    public float enemieSpawnTimer = 0f;
    public int enemieIntervalCount=0;
    private GameObject ttimer;
    private Timer timer;
    public float internalTimer = 0f;
    public GameObject player;
    public GameObject p0, p1, p2, p3, p4, p5, p6, p7, p8, p9;
    private Vector3 p0V, p1V, p2V, p3V, p4V, p5V, p6V, p7V, p8V, p9V;
    private int pause = 1;
    private bool checking=false;
    Dictionary<String,GameObject> patternMatch=new Dictionary<String, GameObject>(30);
    // Start is called before the first frame update
    void Start()
    {
        patternMatch.Add("ghoul", ghoul);
        patternMatch.Add("goblin2", goblin2);
        patternMatch.Add("fly", fly);
        patternMatch.Add("slime", slime);
        patternMatch.Add("redSlime", redSlime);
        patternMatch.Add("skeleton", skeleton);
        patternMatch.Add("imp", imp);
        patternMatch.Add("reaper", reaper);
        ttimer = GameObject.Find("Timer");
        timer=ttimer.GetComponent<Timer>();

        CheckEnemieInterval(enemieIntervalCount);
        random = UnityEngine.Random.Range(0, 9);
        enemieParent = GameObject.Find("Enemies");
        //Thread spawnT = new Thread(() => checkSpawn());
        //spawnT.Start();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        pause = timer.pause;
        internalTimer = timer.timer;
        if (timer.minutes > enemieIntervalCount && timer.minutes <= 30)
        {
            enemieIntervalCount++;
            CheckEnemieInterval(enemieIntervalCount);
        }
        if (pause == 1) transform.position = player.transform.position;
        p0V = p0.transform.position;
        p1V = p1.transform.position;
        p2V = p2.transform.position;
        p3V = p3.transform.position;
        p4V = p4.transform.position;
        p5V = p5.transform.position;
        p6V = p6.transform.position;
        p7V = p7.transform.position;
        p8V = p8.transform.position;
        p9V = p9.transform.position;
        random = UnityEngine.Random.Range(0, 9);
        if (enemieCount < enemieMax && !checking)
        {
            //print("checking");
            checking = true;
            checkSpawn();
        }
    }

    void CheckEnemieInterval(int i)
    {
        switch(i){
            case 0:
                enemieSpawnInterval = 1;
                enemieMax =15;
                enemieSpawnPause = 0.07f;
                enemieName = "goblin2";
                break;
            case 1:
                enemieSpawnInterval = 1;
                enemieSpawnPause = 0.03f;
                enemieMax = 30;
                enemieName = "ghoul";
                break;
            case 2:
                enemieSpawnInterval = 0.5f;
                enemieSpawnPause = 0.01f;
                enemieMax = 50;
                enemieName = "goblin2";
                break;
            case 3:
                enemieSpawnInterval = 0.25f;
                enemieSpawnPause = 0.06f;
                enemieMax = 40;
                enemieName = "fly";
                break;
            case 4:
                enemieSpawnInterval = 1;
                enemieMax = 30;
                enemieSpawnPause = 0.03f;
                enemieName = "fly";
                break;
            case 5:
                enemieSpawnInterval = 1;
                enemieMax = 10;
                enemieSpawnPause = 0.1f;
                enemieName = "slime";
                break;
            case 6:
                enemieSpawnInterval = 0.5f;
                enemieMax = 20;
                enemieSpawnPause = 0.025f;
                enemieName = "ghoul";
                break;
            case 7:
                enemieSpawnInterval = 0.5f;
                enemieMax = 80;
                enemieSpawnPause = 0.00625f;
                enemieName = "goblin2";
                break;
            case 8:
                enemieSpawnInterval = 1.5f;
                enemieMax = 100;
                enemieSpawnPause = 0.015f;
                enemieName = "ghoul";
                break;
            case 9:
                enemieSpawnInterval = 0.5f;
                enemieMax = 30;
                enemieSpawnPause = 0.017f;
                enemieName = "redSlime";
                break;
            case 10:
                enemieSpawnInterval = 0.5f;
                enemieMax = 10;
                enemieSpawnPause = 0.05f;
                enemieName = "slime";
                break;
            case 11:
                enemieSpawnInterval = 0.1f;
                enemieMax = 300;
                enemieSpawnPause = 0.0003f;
                enemieName = "fly";
                break;
            case 12:
                enemieSpawnInterval = 0.25f;
                enemieMax = 20;
                enemieSpawnPause = 0.0125f;
                enemieName = "fly";
                break;
            case 13:
                enemieSpawnInterval = 0.5f;
                enemieMax = 150;
                enemieSpawnPause = 0.003f;
                enemieName = "skeleton";
                break;
            case 14:
                enemieSpawnInterval = 0.1f;
                enemieMax = 20;
                enemieSpawnPause = 0.005f;
                enemieName = "skeleton";
                break;
            case 15:
                enemieSpawnInterval = 0.1f;
                enemieMax = 100;
                enemieSpawnPause = 0.001f;
                enemieName = "slime";
                break;
            case 16:
                enemieSpawnInterval = 0.1f;
                enemieMax = 100;
                enemieSpawnPause = 0.001f;
                enemieName = "redSlime";
                break;
            case 17:
                enemieSpawnInterval = 1;
                enemieMax = 20;
                enemieSpawnPause = 0.05f;
                enemieName = "skeleton";
                break;
            case 18:
                enemieSpawnInterval = 0.5f;
                enemieMax = 60;
                enemieSpawnPause = 0.008f;
                enemieName = "redSlime";
                break;
            case 19:
                enemieSpawnInterval = 0.5f;
                enemieMax = 100;
                enemieSpawnPause = 0.005f;
                enemieName = "redSlime";
                break;
            case 20:
                enemieSpawnInterval = 1;
                enemieMax = 100;
                enemieSpawnPause = 0.01f;
                enemieName = "slime";
                break;
            case 21:
                enemieSpawnInterval = 0.1f;
                enemieMax = 300;
                enemieSpawnPause = 0.003f;
                enemieName = "imp";
                break;
            case 22:
                enemieSpawnInterval = 0.1f;
                enemieMax = 200;
                enemieSpawnPause = 0.0005f;
                enemieName = "goblin2";
                break;
            case 23:
                enemieSpawnInterval = 0.1f;
                enemieMax = 300;
                enemieSpawnPause = 0.0003f;
                enemieName = "redSlime";
                break;
            case 24:
                enemieSpawnInterval = 0.1f;
                enemieMax = 300;
                enemieSpawnPause = 0.0003f;
                enemieName = "imp";
                break;
            case 25:
                enemieSpawnInterval = 0.1f;
                enemieMax = 100;
                enemieSpawnPause = 0.001f;
                enemieName = "fly";
                break;
            case 26:
                enemieSpawnInterval = 0.1f;
                enemieMax = 150;
                enemieSpawnPause = 0.0007f;
                enemieName = "ghoul";
                break;
            case 27:
                enemieSpawnInterval = 0.1f;
                enemieMax = 300;
                enemieSpawnPause = 0.0003f;
                enemieName = "slime";
                break;
            case 28:
                enemieSpawnInterval = 0.1f;
                enemieMax = 300;
                enemieSpawnPause = 0.0003f;
                enemieName = "ghoul";
                break;
            case 29:
                enemieSpawnInterval = 0.1f;
                enemieMax = 300;
                enemieSpawnPause = 0.0003f;
                enemieName = "imp";
                break;
            case 30:
                enemieSpawnInterval = 60;
                enemieMax = 1;
                enemieSpawnPause = 1;
                enemieName = "reaper";
                break;
        }
    }
    void checkSpawn()
    {
        internalTimer = timer.timer;
        if (internalTimer > (enemieSpawnTimer + enemieSpawnPause))
            {
            enemieSpawnTimer = internalTimer;
            if (enemieCount < enemieMax)
            {
                enemieSpawnTimer = internalTimer;
                SpawnEnemyRandomly();
            }
        }
        checking = false;
    }
    void SpawnEnemyRandomly()
    {
        switch (random)
        {
            case 0:
                SpawnEnemy(p0V);
                break; 
            case 1:
                SpawnEnemy(p1V);
                break; 
            case 2:
                SpawnEnemy(p2V);
                break; 
            case 3:
                SpawnEnemy(p3V);
                break; 
            case 4:
                SpawnEnemy(p4V);
                break; 
            case 5:
                SpawnEnemy(p5V);
                break; 
            case 6:
                SpawnEnemy(p6V);
                break; 
            case 7:
                SpawnEnemy(p7V);
                break; 
            case 8:
                SpawnEnemy(p8V);
                break; 
            case 9:
                SpawnEnemy(p9V);
                break;
            default:break;
        }
    }

    void SpawnEnemy(Vector3 pos)
    {
        GameObject obj = Instantiate(patternMatch[enemieName], pos, Quaternion.identity, enemieParent.transform) as GameObject;
    }
}

