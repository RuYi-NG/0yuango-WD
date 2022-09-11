using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigWhaleL: MonoBehaviour
{
    public Rigidbody2D bigwhaleL;
    public float speedx;
    public float speedy;


    // Start is called before the first frame update
    void Start()
    {
        bigwhaleL = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (bigwhaleL.position.y >= 9.66)
        {
            bigwhaleL.velocity = new Vector2(0, 0);
        }
        else
        {
            bigwhaleL.velocity = new Vector2(speedx, speedy);
        }
    }
}
