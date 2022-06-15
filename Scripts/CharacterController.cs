using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{   
    public float speed;
    public float jump;
    public float fall;
    public Animator animator;
    public bool hasFirefly;
    public Vector2 velocity;
    public AudioSource jumpSound; 
    public AudioSource walkSound;
    private bool bounced;
    private bool jumping;
    private bool grounded;
    private bool walkSoundPlaying;

    
    private Rigidbody2D rb;
    private SpriteRenderer sr;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        animator = gameObject.GetComponent<Animator>();
        jumping = false;
        grounded = true;
        bounced = false;
        walkSoundPlaying = false;
        hasFirefly = false;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && grounded)
        {
            Debug.Log("jump");
            jumpSound.Play();
            jumping = true;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            animator.SetBool("walking", true);
            if (Input.GetKey(KeyCode.A))
            {
                velocity = new Vector2(-speed, 0);
                sr.flipX = true;
                if(walkSound != null && grounded)
                {
                  PlayWalkSound();
                }
                
            }

            if (Input.GetKey(KeyCode.D))
            {
                velocity = new Vector2(speed, 0);
                sr.flipX = false;
                if(walkSound != null && grounded)
                {
                  PlayWalkSound();
                }
            }
        }
        else
        {
            animator.SetBool("walking", false);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            velocity = Vector2.zero;
        }
        if(Input.GetKeyDown(KeyCode.C) && sr.flipX == false)
        {
          transform.GetChild(0).gameObject.SetActive(true);
          transform.GetComponentInChildren<Attack>().ToungeAttack();
        }
        else if(Input.GetKeyDown(KeyCode.C) && sr.flipX == true)
        {
          transform.GetChild(1).gameObject.SetActive(true);
          transform.GetComponentInChildren<Attack>().ToungeAttack();
        }

        Debug.DrawLine(new Vector3(transform.position.x, transform.position.y - 0.55f, transform.position.z), new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Color.red);
    }

    void FixedUpdate()
    {
        if(!bounced)
        {
            transform.Translate(velocity);
        }
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
        grounded = Physics2D.BoxCast(new Vector2(position.x, position.y - 0.55f), new Vector2(1, 0.5f), 0f, Vector2.down, 0f, 1 << LayerMask.NameToLayer("Ground"));
    }
    public void Bounced()
    {
        bounced = true;
        Invoke("ResetBounce", 0.2f);
    }
    void ResetBounce()
    {
        bounced = false;
    }
    void PlayWalkSound()
    {
      if(walkSoundPlaying == false && grounded)
      {
        walkSound.Play();
        walkSoundPlaying = true;
        Invoke("ResetWalkSound", 0.2f);
      }
    }
    void ResetWalkSound()
    {
      walkSoundPlaying = false;
    }
}