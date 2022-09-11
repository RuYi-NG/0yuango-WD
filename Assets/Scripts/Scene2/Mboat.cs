using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mboat: MonoBehaviour
{

    public Rigidbody2D boatM;
    public float speedx;


    // Start is called before the first frame update
    void Start()
    {
        boatM = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (boatM.position.x >= -0.5)
        {
           boatM.velocity = new Vector2(-speedx, 0);
        }
        else
        {
           boatM.velocity = new Vector2(0, 0);
        }
    }
}
