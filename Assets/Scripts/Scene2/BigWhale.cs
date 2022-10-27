using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWhale: MonoBehaviour
{
    private Rigidbody2D rb;
    public float speedx;
    public float speedy;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (rb.position.y >= 10)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speedx, speedy);
        }
    }
}
