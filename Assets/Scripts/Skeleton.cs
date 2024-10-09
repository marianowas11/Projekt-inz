using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    // Start is called before the first frame update
    public EnemyHealth enemyHealth;
    public EnemyDmg enemyDmg;
    public EnemyMovement enemyMovement;

    public float baseMaxHp = 180;
    public float maxHp = 180;
    public float dmg = 14;
    public float baseSpeed = 1.3f;
    public float speed = 1.3f;

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
