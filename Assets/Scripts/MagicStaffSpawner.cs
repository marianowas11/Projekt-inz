using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MagicStaffSpawner : MonoBehaviour
{
    public StatManager statManager;
    public ItemManager itemManager;
    public Timer timer;
    public GameObject magicBulletPrefab;
    private GameObject player;
    //public Dagger dagger;

    private float baseDmg = 10f;
    private float bonusDmg;
    [System.NonSerialized]public float totalDmg;
    private int baseProjectiles = 1;
    [System.NonSerialized] public float baseSpeed = 1;
    private float bonusSpeed;
    [System.NonSerialized]public int pierce = 0;
    private int lvl = 1;
    private int maxLvl = 8;
    private float interval = 0.1f;
    private float cooldown = 1.2f;

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
        itemManager.wandLvl= lvl;
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
    public void LvlUp()
    {
        if(lvl<maxLvl)lvl++;
        itemManager.wandLvl = lvl;
    }
    public void UpdateStats()
    {
        switch(lvl)
        {
            case 1:
                baseDmg = 10f;
                totalDmg = ConvertNumber(baseDmg,statManager.might);
                baseProjectiles = 1+statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed,statManager.speed);
                pierce = 0;
                interval = 0.1f;
                cooldown = ConvertNumber(1.2f,statManager.cooldown);
                break;
            case 2:
                baseDmg = 10f;
                totalDmg = ConvertNumber(baseDmg, statManager.might);
                baseProjectiles = 2 + statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed, statManager.speed);
                pierce = 0;
                interval = 0.1f;
                cooldown = ConvertNumber(1.2f, statManager.cooldown);
                break;
            case 3:
                baseDmg = 10f;
                totalDmg = ConvertNumber(baseDmg, statManager.might);
                baseProjectiles = 2 + statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed, statManager.speed);
                pierce = 0;
                interval = 0.1f;
                cooldown = ConvertNumber(1f, statManager.cooldown);
                break;
            case 4:
                baseDmg = 10f;
                totalDmg = ConvertNumber(baseDmg, statManager.might);
                baseProjectiles = 3 + statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed, statManager.speed);
                pierce = 0;
                interval = 0.1f;
                cooldown = ConvertNumber(1f, statManager.cooldown);
                break;
            case 5:
                baseDmg = 20f;
                totalDmg = ConvertNumber(baseDmg, statManager.might);
                baseProjectiles = 3 + statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed, statManager.speed);
                pierce = 0;
                interval = 0.1f;
                cooldown = ConvertNumber(1f, statManager.cooldown);
                break;
            case 6:
                baseDmg = 20f;
                totalDmg = ConvertNumber(baseDmg, statManager.might);
                baseProjectiles = 4 + statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed, statManager.speed);
                pierce = 0;
                interval = 0.1f;
                cooldown = ConvertNumber(1f, statManager.cooldown);
                break;
            case 7:
                baseDmg = 20f;
                totalDmg = ConvertNumber(baseDmg, statManager.might);
                baseProjectiles = 4 + statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed, statManager.speed);
                pierce = 1;
                interval = 0.1f;
                cooldown = ConvertNumber(1f, statManager.cooldown);
                break;
            case 8:
                baseDmg = 30f;
                totalDmg = ConvertNumber(baseDmg, statManager.might);
                baseProjectiles = 4 + statManager.amount;
                baseSpeed = ConvertNumber(baseSpeed, statManager.speed);
                pierce = 1;
                interval = 0.1f;
                cooldown = ConvertNumber(1f, statManager.cooldown);
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
        GameObject obj = Instantiate(magicBulletPrefab, transform.position, Quaternion.identity) as GameObject;
        lastSpawned = timer.timer;
        alreadySpawned++;


    }
}
