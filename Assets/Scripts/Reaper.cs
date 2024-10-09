using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reaper : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyHealth enemyHealth;
    public EnemyDmg enemyDmg;
    public EnemyMovement enemyMovement;

    public float baseMaxHp = 10000;
    public float maxHp = 10000;
    public float dmg = 1000;
    public float baseSpeed = 15f;
    public float speed = 30f;

    public GameObject sstatManager;
    public StatManager statManager;
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyDmg = GetComponent<EnemyDmg>();
        enemyMovement = GetComponent<EnemyMovement>();
        sstatManager = GameObject.Find("StatManager");
        statManager = sstatManager.GetComponent<StatManager>();
        CheckStats();
    }

    // Update is called once per frame
    void Update()
    {
        CheckStats();
        
    }
    public void CheckStats()
    {
        maxHp = ConvertNumber(baseMaxHp, statManager.curse);
        speed = ConvertNumber(baseSpeed, statManager.curse);
        enemyMovement.moveSpeed = speed;
        enemyHealth.maxHp = maxHp;
        enemyDmg.damage = dmg;
    }
    private float ConvertNumber(float n1, float n2)
    {
        string smt = String.Format("{0}", (100000 * n1 * n2));

        return (float.Parse(smt) / 100000);
    }
}
