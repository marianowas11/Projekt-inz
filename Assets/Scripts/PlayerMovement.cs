using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int time = 1;
    private float moveSpeed = 1.4f;
    private bool left, right;

    // Start is called before the first frame update
    void Start()
    {
        right = true; left=false;
    }

    // Update is called once per frame
    void Rotation(int i)
    {//obrócenie postaci
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y = i;
        transform.rotation = Quaternion.Euler(rotationVector);
    }
    void Update()
    {//wczytywanie wciœniêtych klawiszy
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");
        if (moveHorizontal < 0 && !left)
        {//sprawdzanie kierunku ruchu by obróciæ postaæ
            right = false; left=true;
            Rotation(180);
        }
        if (moveHorizontal > 0 && !right)
        {//sprawdzanie kierunku ruchu by obróciæ postaæ
            left = false;right= true;
            Rotation(0); 
        }// \/ \/ Ruch postaci
        Vector3 newMovement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        transform.position = transform.position + newMovement * Time.deltaTime * moveSpeed;
    }
}
