using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallWhale : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speedx;
    public float speedy;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (rb.position.y >= 8.65)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speedx, speedy);
        }
    }
}
