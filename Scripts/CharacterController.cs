using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{   
    public float speed;
    public float jump;
    public float fall;

    private Vector2 velocity;
    private bool jumping;
    private bool grounded;
    private Rigidbody2D rb;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        jumping = false;
        grounded = true;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && grounded)
        {
            grounded = false;
            jumping = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            velocity = new Vector2(-speed, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            velocity = new Vector2(speed, 0);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            velocity = Vector2.zero;
        }
        // if(Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.W))
        // {
        //     jumpVelocity = Vector2.zero;
        // }
    }

    void FixedUpdate()
    {
        transform.Translate(velocity);
        if (jumping)
        {
            rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
            jumping = false;
        }

        if (rb.velocity.y < 0 && !grounded)
        {
            rb.AddForce(-1 * transform.up * fall, ForceMode2D.Impulse);
            Debug.Log("down test");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            grounded = true;
        }
    }
}
