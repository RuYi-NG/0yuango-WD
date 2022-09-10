using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scene2boat : MonoBehaviour
{
    public Rigidbody2D boatL;
    public float speedx;


    // Start is called before the first frame update
    void Start()
    {
        boatL = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (bigWhaleL.bigwhaleL.position.y >= 9.66)
        {

        }
    }
}
