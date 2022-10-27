using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lboat : MonoBehaviour
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
        if (boatL.position.x >= -5.6)
        {
            boatL.velocity = new Vector2(0, 0);
        }
        else
        {
            boatL.velocity = new Vector2(speedx, 0);
        }
    }
}
