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
            // grounded = false;
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

        Debug.DrawLine(new Vector3(transform.position.x, transform.position.y - 0.55f, transform.position.z), new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Color.red);
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
        }
        
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        // grounded = Physics2D.Raycast(new Vector2(position.x, position.y - 0.55f), Vector2.down, 1f, 1 << LayerMask.NameToLayer("Ground"));
        grounded = Physics2D.BoxCast(new Vector2(position.x, position.y - 0.55f), new Vector2(1, 0.5f), 0f, Vector2.down, 0f, 1 << LayerMask.NameToLayer("Ground"));
        
    }
}