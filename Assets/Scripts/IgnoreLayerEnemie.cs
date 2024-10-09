using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreLayerEnemie : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Enemie"),LayerMask.NameToLayer("Loot"),true);
        //Physics2D.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
