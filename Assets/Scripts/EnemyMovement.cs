using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameObject player;
    private GameObject ttimer;
    private Timer timer;
    private int pause;
    private Vector3 playerPosition;
    private Vector3 direction;
    private Vector2 movement;
    [System.NonSerialized] public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        ttimer = GameObject.Find("Timer");
        timer = ttimer.GetComponent<Timer>();
        pause = timer.pause;

        rb = GetComponent<Rigidbody2D>();

        player = GameObject.Find("player");
        playerPosition=player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        CheckToDelete();


    }
    private void CheckToDelete()
    {
        float smt = Vector3.Distance(player.transform.position, transform.position);
        if (smt > 30)
        {
            GameObject go = gameObject;
            EnemyHealth eH=go.GetComponent<EnemyHealth>();
            eH.Despawn();
        }
    }
    private void FixedUpdate()
    {
        pause = timer.pause;
        if (pause == 1) playerPosition = player.transform.position;
        direction = playerPosition - transform.position;
        direction.Normalize();
        movement = direction;
        if (pause == 1) CheckRotation();
        if (pause==1)MoveCharacter(movement);
    }
    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime * pause));
    }
    void CheckRotation()
    {
        if (direction.x < 0) Rotation(-180);
        if (direction.x > 0) Rotation(0);
    }
    void Rotation(int i)
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = i;
        transform.rotation = Quaternion.Euler(rotationVector);
    }
}
