using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigid;
    private float movement;
    private SpriteRenderer sprite;
    Animator animator;

    [SerializeField] private float JUMPFORCE = 5f;
    [SerializeField] private float SPEED = 6f;
    [SerializeField] private LayerMask jumpableGround;
    private BoxCollider2D coll;
    private enum MovementState { idle, running, jumping, falling };

    [SerializeField] private AudioSource jumpSoundEffect;
    [SerializeField] private AudioSource shootSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if (animator == null)
            animator = GetComponent<Animator>();
        if(sprite == null)
            sprite = GetComponent<SpriteRenderer>();   
        if(coll == null)
            coll = GetComponent<BoxCollider2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(movement * SPEED, rigid.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rigid.velocity = new Vector2(rigid.velocity.x, JUMPFORCE);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            shootSoundEffect.Play();
        }
    }
    //can be called potentially many times per frame -- best for physics
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(movement * SPEED, rigid.velocity.y);
        UpdateAnimationState();
    
    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (movement > 0f)
        {
            state = MovementState.running;
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (movement < 0f)
        {
            state = MovementState.running;
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            state = MovementState.idle;
        }

        if (rigid.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rigid.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
