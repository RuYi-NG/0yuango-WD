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
    private SpriteRenderer rend;


    // Start is called before the first frame update
    void Start()
    {
        interact = GameObject.Find("Interact").GetComponent<Button>();
        rend = GameObject.Find("Mainchar").GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 1f;
        rend.material.color = c;
    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f) {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    IEnumerator FadeOut()
    {
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
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
        float Scalex = Mathf.Abs(gameObject.transform.localScale.x);
        float horizontalmove = joystick.Horizontal;
        rb.velocity = new Vector2(horizontalmove * speed * Time.deltaTime, rb.velocity.y);

        if (horizontalmove > 0f) 
        {
            transform.localScale = new Vector3(Scalex * -1, gameObject.transform.localScale.y * 1, gameObject.transform.localScale.z * 1);
        }
        if (horizontalmove < 0f)
        {
            transform.localScale = new Vector3(Scalex * 1, gameObject.transform.localScale.y * 1, gameObject.transform.localScale.z * 1);
        }
    }
    public void Hide()
    {
        if (hiding == true)
        {
            Physics2D.IgnoreLayerCollision(6, 7, false);
            Physics2D.IgnoreLayerCollision(6, 8, false);
            hiding = false;
            StartCoroutine("FadeIn");
        }
        else if (canHide)
        {
            Physics2D.IgnoreLayerCollision(6, 7, true);
            Physics2D.IgnoreLayerCollision(6, 8, true);
            hiding = true;
            StartCoroutine("FadeOut");
            }
        }
}
