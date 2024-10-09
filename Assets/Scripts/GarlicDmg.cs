using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicDmg : MonoBehaviour
{
    public GameObject ggarlic;
    public Garlic garlic;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        ggarlic = GameObject.Find("garlic");
        garlic= GetComponent<Garlic>();
        damage = garlic.garlicDamage;
    }

    // Update is called once per frame
    void Update()
    {
        damage = garlic.garlicDamage;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().garlicDamage = damage;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.GetComponent<EnemyHealth>().garlicDamage= damage;
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
}
