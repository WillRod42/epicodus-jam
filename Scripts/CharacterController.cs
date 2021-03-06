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
    public bool hasFirefly;
    public AudioClip jumpSound; 
    public AudioClip walkSound;

    private bool bounced;
    private bool jumpPressed;
    private bool grounded;
    private bool facingRight;
    private bool attacking;
    private bool attackPressed;
    private string currentState;
    private bool walkSoundPlaying;
    
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator animator;
    private AudioSource player;

    const string PLAYER_IDLE = "Idle";
    const string PLAYER_WALK = "Walk";
    const string PLAYER_ATTACK = "Attack";
    const string PLAYER_JUMP = "Jump";
    const string PLAYER_WALK_ATTACK = "Walk Attack";
    const string PLAYER_JUMP_ATTACK = "Air Attack";
    const float ATTACK_DELAY = 1f;
    const float JUMP_ATTACK_DELAY = 2f / 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = playerSprite.GetComponent<SpriteRenderer>();
        animator = playerSprite.GetComponent<Animator>();
        player = GetComponent<AudioSource>();
        
        jumpPressed = false;
        grounded = true;
        bounced = false;
        facingRight = true;
        attacking = false;
        walkSoundPlaying = false;
        hasFirefly = false;

        ChangeAnimationState(PLAYER_IDLE);
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)) && grounded)
        {
            PlayJumpSound();
            jumpPressed = true;
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
        if((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.C)) && sr.flipX == false)
        {
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetComponentInChildren<Attack>().ToungeAttack();
            attackPressed = true;
        }
        else if((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.C)) && sr.flipX == true)
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetComponentInChildren<Attack>().ToungeAttack();
            attackPressed = true;
        }
    }

    void FixedUpdate()
    {
        if(!bounced)
        {
            transform.Translate(velocity);
        }

        if (jumpPressed)
        {
            rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
            jumpPressed = false;

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
        grounded = Physics2D.BoxCast(new Vector2(position.x, position.y - 0.6f), new Vector2(0.4f, 0.1f), 0f, Vector2.down, 0f, 1 << LayerMask.NameToLayer("Ground"));

        if (attackPressed)
        {
            attackPressed = false;
            if (!attacking)
            {
                attacking = true;
                if (!grounded)
                {
                    ChangeAnimationState(PLAYER_JUMP_ATTACK);
                    Invoke("AttackFinished", JUMP_ATTACK_DELAY);
                }
                else if (velocity.x != 0)
                {
                    ChangeAnimationState(PLAYER_WALK_ATTACK);
                    Invoke("AttackFinished", ATTACK_DELAY);
                }
                else
                {
                    ChangeAnimationState(PLAYER_ATTACK);
                    Invoke("AttackFinished", ATTACK_DELAY);
                }
                
            }
        }

        if (!attacking && grounded)
        {
            if (velocity.x != 0)
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
    }

    private void AttackFinished()
    {
        attacking = false;
    }

    private void PlayJumpSound()
    {
        player.clip = jumpSound;
        player.Play();
    }
    
    private void PlayWalkSound()
    {
        if(walkSoundPlaying == false && grounded)
        {
        player.clip = walkSound;
        player.Play();
        walkSoundPlaying = true;
        Invoke("ResetWalkSound", 0.2f);
        }
    }
    
    private void ResetWalkSound()
    {
        walkSoundPlaying = false;
    }
}
