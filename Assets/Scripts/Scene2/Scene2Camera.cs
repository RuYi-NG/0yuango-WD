using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2Camera : MonoBehaviour
{
    private Rigidbody2D cam;
    public float speed;
    
    

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Rigidbody2D>();
    }

   

    void Update()
    {
        Movement();
    }
    void Movement() 
    {
        if(cam.position.y >= 10.4)
        {
            cam.velocity = new Vector2(0, 0);
        }
        else 
        {
            cam.velocity = new Vector2(0, speed); 
        }
        
    }

}
