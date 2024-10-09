using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDmg : MonoBehaviour
{
    //public EnemyHealth enemyHealth;
    public float damage = 2;
    //ContactFilter2D contactFilter;
    //public float radius;
    //new Vector3 pozycja;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //pozycja = transform.position;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().garlicArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().garlicArea = false;
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Area();
        }
    }*/

    /*private void Area()
    {
        Collider2D[] colliders = new Collider2D[100];
        int hitCount = Physics2D.OverlapCircle(pozycja, radius, contactFilter, colliders);
        foreach(Collider2D collider in colliders)
        {
            if (collider.gameObject.tag == "Enemy")
            {
                collider.GetComponent<EnemyHealth>().TakeDamage(damage);

            }
        }
    }*/
}
