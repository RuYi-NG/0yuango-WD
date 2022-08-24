using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Joystick joystick;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        GroundMovement();
    }


    void GroundMovement() 
    {
        float horizontalmove = joystick.Horizontal;
        rb.velocity = new Vector2(horizontalmove * speed * Time.deltaTime, rb.velocity.y);

        if (horizontalmove > 0f) 
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (horizontalmove < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
