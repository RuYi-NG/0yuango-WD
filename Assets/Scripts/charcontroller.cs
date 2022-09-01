using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charcontroller : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;
    public Joystick joystick;
    private bool canHide = false;
    private bool hiding = false;
    private Button interact;
    


    // Start is called before the first frame update
    void Start()
    {
        interact = GameObject.Find("Interact").GetComponent<Button>();

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        GroundMovement();

        if (!hiding)
        {
            speed = 100;
        }
        else
        {
            speed = 0;
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Hidable"))
        {
            canHide = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Hidable"))
        {
            canHide = false;
        }
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
    public void hide()
    {
        if (hiding == true)
        {
            Physics2D.IgnoreLayerCollision(6, 7, false);
            Physics2D.IgnoreLayerCollision(6, 8, false);
            hiding = false;
        }
        else if (canHide)
        {
            Physics2D.IgnoreLayerCollision(6, 7, true);
            Physics2D.IgnoreLayerCollision(6, 8, true);
            hiding = true;
        }
    }
}
