using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rboat : MonoBehaviour
{
    public Rigidbody2D boatR;
    public float speedx;


    // Start is called before the first frame update
    void Start()
    {
        boatR = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        if (boatR.position.x >= 7.5)
        {
            boatR.velocity = new Vector2(-speedx, 0);
        }
        else
        {
            boatR.velocity = new Vector2(0, 0);
        }
    }
}
