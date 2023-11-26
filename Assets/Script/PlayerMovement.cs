using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Animator animator;

    [SerializeField] private float JUMPFORCE = 5f;
    [SerializeField] private float SPEED = 6f;
    [SerializeField] private LayerMask jumpableGround;
    private BoxCollider2D coll;
    private enum MovementState { idle, running, jumping, falling };
   
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
            rigid.velocity = new Vector2(rigid.velocity.x, JUMPFORCE);
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
            sprite.flipX = false;
        }
        else if (movement < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
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
