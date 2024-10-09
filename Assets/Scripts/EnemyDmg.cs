using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDmg : MonoBehaviour
{
    public GameObject player;
    public PlayerHealth playerHealth;
    [System.NonSerialized] public float damage = 2;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
