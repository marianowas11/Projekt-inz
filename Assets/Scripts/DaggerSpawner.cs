using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class DaggerSpawner : MonoBehaviour
{
    public StatManager statManager;
    public ItemManager itemManager;
    public Timer timer;
    public GameObject daggerPrefab;
    public GameObject player;
    //public Dagger dagger;

    private float baseDmg = 6.5f;
    private float bonusDmg;
    [System.NonSerialized]public float totalDmg;
    private int baseProjectiles = 1;
    [System.NonSerialized] public float baseSpeed = 1;
    private float bonusSpeed;
    [System.NonSerialized]public int pierce = 0;
    private int lvl = 1;
    private int maxLvl = 8;
    private float interval = 0.1f;
    private float cooldown = 1f;

    private float lastSpawned;
    private int alreadySpawned;
    private bool onCooldown;
    void Start()
    {
        player = GameObject.Find("player");
        lastSpawned = -1;
        alreadySpawned = 0;
        onCooldown = false;
        UpdateStats();
        itemManager.daggerLvl = lvl;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStats();
        CheckIfSpawn();
    }

    private void CheckIfSpawn()
    {
        if (alreadySpawned == baseProjectiles)
        {
            onCooldown = true;
            alreadySpawned = 0;
        }
        if (timer.timer >= lastSpawned + cooldown)
        {
            onCooldown = false;
        }

        if (timer.timer >= lastSpawned + interval && !onCooldown)
        {
            Spawn();
        }
    }
    public void DaggerLvlUp()
    {
        if(lvl<maxLvl)lvl++;
        itemManager.daggerLvl = lvl;
    }
    public void UpdateStats()
    {
        switch(lvl)
        {
            case 1:
                baseDmg = 6.5f;
                totalDmg = ConvertNumber(baseDmg,statManager.might);
                baseProjectiles = 1+statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed,statManager.speed);
                pierce = 0;
                interval = 0.1f;
                cooldown = ConvertNumber(1,statManager.cooldown);
                break;
            case 2:
                baseDmg = 6.5f;
                totalDmg = ConvertNumber(baseDmg, statManager.might);
                baseProjectiles = 2 + statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed, statManager.speed);
                pierce = 0;
                interval = 0.1f;
                cooldown = ConvertNumber(1, statManager.cooldown);
                break;
            case 3:
                baseDmg = 11.5f;
                totalDmg = ConvertNumber(baseDmg, statManager.might);
                baseProjectiles = 3 + statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed, statManager.speed);
                pierce = 0;
                interval = 0.1f;
                cooldown = ConvertNumber(1, statManager.cooldown);
                break;
            case 4:
                baseDmg = 11.5f;
                totalDmg = ConvertNumber(baseDmg, statManager.might);
                baseProjectiles = 4 + statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed, statManager.speed);
                pierce = 0;
                interval = 0.08f;
                cooldown = ConvertNumber(1, statManager.cooldown);
                break;
            case 5:
                baseDmg = 11.5f;
                totalDmg = ConvertNumber(baseDmg, statManager.might);
                baseProjectiles = 4 + statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed, statManager.speed);
                pierce = 1;
                interval = 0.08f;
                cooldown = ConvertNumber(1, statManager.cooldown);
                break;
            case 6:
                baseDmg = 11.5f;
                totalDmg = ConvertNumber(baseDmg, statManager.might);
                baseProjectiles = 5 + statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed, statManager.speed);
                pierce = 1;
                interval = 0.06f;
                cooldown = ConvertNumber(1, statManager.cooldown);
                break;
            case 7:
                baseDmg = 16.5f;
                totalDmg = ConvertNumber(baseDmg, statManager.might);
                baseProjectiles = 6 + statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed, statManager.speed);
                pierce = 1;
                interval = 0.06f;
                cooldown = ConvertNumber(1, statManager.cooldown);
                break;
            case 8:
                baseDmg = 16.5f;
                totalDmg = ConvertNumber(baseDmg, statManager.might);
                baseProjectiles = 6 + statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed, statManager.speed);
                pierce = 2;
                interval = 0.04f;
                cooldown = ConvertNumber(1, statManager.cooldown);
                break;
        }
    }
    private float ConvertNumber(float n1, float n2)
    {
        string smt = String.Format("{0}", (100000 * n1 * n2));

        return (float.Parse(smt) / 100000);
    }
    void Spawn()
    {
        if (player.transform.rotation.y >= 0)
            {
            GameObject obj = Instantiate(daggerPrefab, transform.position, new Quaternion(0f,0f,0f,0f)) as GameObject;
            lastSpawned = timer.timer;
            alreadySpawned++;
        }
        if (player.transform.rotation.y < 0)
        {
            GameObject obj = Instantiate(daggerPrefab, transform.position, new Quaternion(0f, 0f, 1f, 0f)) as GameObject;
            lastSpawned = timer.timer;
            alreadySpawned++;
        }

    }
}
