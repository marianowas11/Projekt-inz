using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    private GameObject sstatManager;
    private StatManager statManager;
    private GameObject player;
    private GameObject ttimer;
    private Timer timer;
    private int pause;

    [System.NonSerialized] public float magnetArea;
    // Start is called before the first frame update
    void Start()
    {
        ttimer = GameObject.Find("Timer");
        timer= ttimer.GetComponent<Timer>();
        player = GameObject.Find("player");
        sstatManager = GameObject.Find("StatManager");
        statManager = sstatManager.GetComponent<StatManager>();
        magnetArea = statManager.magnetArea;
        pause = timer.pause;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

            if (collision.gameObject.tag == "coin")
            {
                FollowPlayer(collision.gameObject, collision.gameObject.GetComponent<Rigidbody2D>());
            }
            else if (collision.gameObject.tag == "expGem")
            {
                FollowPlayer(collision.gameObject, collision.gameObject.GetComponent<Rigidbody2D>());
            }
            else if (collision.gameObject.tag == "food")
            {
                FollowPlayer(collision.gameObject, collision.gameObject.GetComponent<Rigidbody2D>());
            }
            else if (collision.gameObject.tag == "goldVacuum")
            {
                FollowPlayer(collision.gameObject, collision.gameObject.GetComponent<Rigidbody2D>());
            }
            else if (collision.gameObject.tag == "coin2")
            {
                FollowPlayer(collision.gameObject, collision.gameObject.GetComponent<Rigidbody2D>());
            }
            else if (collision.gameObject.tag == "coin3")
            {
                FollowPlayer(collision.gameObject, collision.gameObject.GetComponent<Rigidbody2D>());
            }
            else if (collision.gameObject.tag == "rosary")
            {
                FollowPlayer(collision.gameObject, collision.gameObject.GetComponent<Rigidbody2D>());
            }
            else if (collision.gameObject.tag == "smallClover")
            {
                FollowPlayer(collision.gameObject, collision.gameObject.GetComponent<Rigidbody2D>());
            }
            else if (collision.gameObject.tag == "Vacuum")
            {
                FollowPlayer(collision.gameObject, collision.gameObject.GetComponent<Rigidbody2D>());
            }
        
    }

    public void FollowPlayer(GameObject gb, Rigidbody2D rb)
    {
        Vector3 playerPosition = player.transform.position;
        pause = timer.pause;
        Vector2 direction = playerPosition - gb.transform.position;
        direction.Normalize();
        Vector2 movement = direction;
        int moveSpeed = 10;
        gb.transform.position = (Vector2)gb.transform.position + (movement * moveSpeed * Time.deltaTime * pause);
    }
}
