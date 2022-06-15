using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{   
    public float speed;
    public float jump;
    public float fall;
    public Vector2 velocity;
    public GameObject playerSprite;
    public Animator animator;
    public bool hasFirefly;
    public AudioSource jumpSound; 
    public AudioSource walkSound;

    private bool bounced;
    private bool jumping;
    private bool grounded;
    private bool facingRight;
    private bool attacking;
    private bool attackPressed;
    private string currentState;
    private float attackDelay;
    private bool walkSoundPlaying;
    
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;

    const string PLAYER_IDLE = "Idle";
    const string PLAYER_WALK = "Walk";
    const string PLAYER_ATTACK = "Attack";
    const string PLAYER_JUMP = "Jump";

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = playerSprite.GetComponent<SpriteRenderer>();
        animator = playerSprite.GetComponent<Animator>();
        
        jumping = false;
        grounded = true;
        bounced = false;
        facingRight = true;
        attacking = false;
        attackDelay = 0.5f;
        walkSoundPlaying = false;
        hasFirefly = false;

        ChangeAnimationState(PLAYER_IDLE);
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
            if (Input.GetKey(KeyCode.A))
            {
                velocity = new Vector2(-speed, 0);
                facingRight = false;
                if(walkSound != null && grounded)
                {
                  PlayWalkSound();
                }
            }

            if (Input.GetKey(KeyCode.D))
            {
                velocity = new Vector2(speed, 0);
                facingRight = true;
                if(walkSound != null && grounded)
                {
                  PlayWalkSound();
                }
            }
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

        if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)))
        {
            attackPressed = true;
        }
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

            if (!attacking)
            {
                ChangeAnimationState(PLAYER_JUMP);
            }
        }

        if (rb.velocity.y < 0 && !grounded)
        {
            rb.AddForce(-1 * transform.up * fall, ForceMode2D.Impulse);
        }
        
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        grounded = Physics2D.BoxCast(new Vector2(position.x, position.y - 0.55f), new Vector2(1, 0.5f), 0f, Vector2.down, 0f, 1 << LayerMask.NameToLayer("Ground"));

        if (attackPressed)
        {
            attackPressed = false;
            if (!attacking)
            {
                attacking = true;
                ChangeAnimationState(PLAYER_ATTACK);
                Invoke("AttackFinished", attackDelay);
            }
        }

        if (!attacking)
        {
            if (Mathf.Abs(velocity.x) > 0)
            {
                ChangeAnimationState(PLAYER_WALK);
            }
            else if (grounded)
            {
                ChangeAnimationState(PLAYER_IDLE);
            }
        }
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

    private void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        if (facingRight)
        {
            newState += " Right";
        }
        else
        {
            newState += " Left";
        }

        animator.Play(newState);
        currentState = newState;

        // Debug.Log("1 - " + animator.GetCurrentAnimatorClipInfo(0)[0].clip.name);
    }

    private void AttackFinished()
    {
        attacking = false;
    }
    
    private void PlayWalkSound()
    {
      if(walkSoundPlaying == false && grounded)
      {
        walkSound.Play();
        walkSoundPlaying = true;
        Invoke("ResetWalkSound", 0.2f);
      }
    }
    
    private void ResetWalkSound()
    {
      walkSoundPlaying = false;
    }
}