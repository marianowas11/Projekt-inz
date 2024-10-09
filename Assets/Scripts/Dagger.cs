using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;

public class Dagger : MonoBehaviour
{
    public GameObject daggerSpawner;
    public DaggerSpawner spawner;

    public GameObject player;


    private float dmg;
    private float speed;
    private int pierce;
    private int pierced;
    private UnityEngine.Vector3 direction,bpos;
    //int direction;

    void Start()
    {
        pierced= 0;
        player = GameObject.Find("player");
        bpos=transform.position;
        daggerSpawner = GameObject.Find("DaggerSpawner");
        spawner=daggerSpawner.GetComponent<DaggerSpawner>();
        UpdateStats();
        if (transform.rotation.y >= 0) direction = new Vector3(1, 0, 0);
        if (transform.rotation.y < 0) direction = new Vector3(-1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(pierced>pierce) Destroy(gameObject);
        UpdateStats();
        Move();
        CheckToDelete();
    }
    private void UpdateStats()
    {
        dmg=spawner.totalDmg; 
        speed=spawner.baseSpeed;
        pierce=spawner.pierce;
    }
    private void Move()
    {
        transform.Translate(direction * Time.deltaTime * speed*15);
    }
    private void CheckToDelete()
    {
        float smt = UnityEngine.Vector3.Distance(bpos, transform.position);
        if (smt > 30)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(dmg);
            pierced++;
        }
    }
}
