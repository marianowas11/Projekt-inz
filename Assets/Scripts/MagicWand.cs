using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MagicWand : MonoBehaviour
{
    public GameObject magicStaffSpawner;
    public MagicStaffSpawner spawner;

    public GameObject player;


    private float dmg;
    private float speed;
    private int pierce;
    private int pierced;
    private UnityEngine.Vector3 direction;
    public Vector3 bpos;
    private GameObject closest;
    private Vector3 enemyPosition;
    //int direction;
    //List<Tuple<GameObject,float>> list=new List<Tuple<GameObject,float>>();
    void Start()
    {
        player = GameObject.Find("player");
        magicStaffSpawner = GameObject.Find("MagicStaffSpawner");
        spawner = magicStaffSpawner.GetComponent<MagicStaffSpawner>();
        bpos = player.transform.position;
        enemyPosition =CheckClosest().transform.position;
        direction = enemyPosition - transform.position;
        pierced = 0;
        UpdateStats();
    }

    // Update is called once per frame
    void Update()
    {
        if (pierced > pierce) Destroy(gameObject);
        UpdateStats();
        Move();
        CheckToDelete();
    }
    private void UpdateStats()
    {
        dmg = spawner.totalDmg;
        speed = spawner.baseSpeed;
        pierce = spawner.pierce;
    }
    private void Move()
    {
        transform.Translate(direction * Time.deltaTime * speed);
    }
    private void CheckToDelete()
    {
        float smt = Vector3.Distance(bpos, transform.position);
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
    private GameObject CheckClosest()
    {
        int count = 0;
        List<Tuple<GameObject, float>> list = new List<Tuple<GameObject, float>>();
        foreach (GameObject e in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            count++;
            list.Add(new Tuple<GameObject,float>(e, Vector3.Distance(bpos, e.transform.position)));
        }
        var sorted = list.OrderByDescending(t =>t.Item2).ToList();
        GameObject last= sorted[count - 1].Item1;
        return last;
    }
}