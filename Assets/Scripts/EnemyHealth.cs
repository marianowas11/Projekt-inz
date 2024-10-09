using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private GameObject lloot;
    private GameObject sMap1;
    private GameObject sManager;
    private GameObject ttimer;
    private LootSpawner lootSpawner;
    private Timer timer;
    public HealthBar healthBar;
    public SpawnControl spawnControl;
    public StatManager statManager;
    public float internalTimer = 0;
    public float garlicTimer = 0;
    public float garlicStartTimer = 0;
    public float garlicDamage;
    [System.NonSerialized] public float maxHp;
    [System.NonSerialized] public float hp;
    private bool death = false;
    private bool countTimer=true;
    private int pause;

    public bool garlicArea;
    public float garlicSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        lloot = GameObject.Find("Loot");
        ttimer = GameObject.Find("Timer");
        sMap1 = GameObject.Find("SpawnerMap1");
        sManager = GameObject.Find("StatManager");
        lootSpawner=lloot.GetComponent<LootSpawner>();
        timer = ttimer.GetComponent<Timer>();
        spawnControl=sMap1.GetComponent<SpawnControl>();
        spawnControl.enemieCount++;
        statManager=sManager.GetComponent<StatManager>();
        pause = timer.pause;
        hp = maxHp;

        garlicSpeed = statManager.garlicSpeed;
        healthBar.SetMaxHealth(maxHp, maxHp);
    }
    

    void Update()
    {
        pause = timer.pause;
        healthBar.SetMaxHealth(maxHp, hp);
        garlicSpeed = statManager.garlicSpeed;
        if (garlicArea)
        {
            GarlicTimer();
            CheckForGarlicDamage();
        }
        if(!garlicArea && countTimer)
        {
            garlicTimer= 0;
            garlicStartTimer = 0;
            countTimer = false;
        }
        if (death)
        {
            
            Death();
        }
        //garlicDamage();
    }
    private void CheckForGarlicDamage()
    {
        if (garlicStartTimer == 0)
        {         
            garlicStartTimer = garlicTimer;
            GarlicDamage();
        }
        if(garlicTimer>garlicStartTimer+garlicSpeed)
        {
            garlicStartTimer = garlicTimer;
            GarlicDamage();
        }
    }
    private void GarlicTimer()
    {
        countTimer= true;
        if (garlicTimer >= 0 && pause == 1)
        {
            garlicTimer += Time.deltaTime;
        }
        else
        {
            print("paused");
        }
    }

    public void GarlicDamage()
    {
            TakeDamage(garlicDamage);
    }


    public void Death()
    {
        spawnControl.enemieCount--;
        statManager.deadEnemies++;
        lootSpawner.SpawnLoot(transform.position);
        Destroy(gameObject);
    }
    public void Despawn()
    {
        spawnControl.enemieCount--;
        Destroy(gameObject);
    }
    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        if (hp <= 0) death=true;
    }
}
