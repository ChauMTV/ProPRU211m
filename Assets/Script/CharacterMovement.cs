using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator am;
    private SpriteRenderer sprite;
    private bool moveLeft;
    private bool moveRight;
    private bool jump;
    private float horizontalMove;
    private Vector2 rollingDir;
    private float rollingTime = 0.2f;
    private float rollingCoolDown = 1f;
    public float JumpTimeCounter;
    public float jumping;
    public bool canDoubleJump;
    private bool isJump;


    [SerializeField] private float speed = 7f;
    [SerializeField] private float rollingSpeed = 16f;
    [SerializeField] private float jumpspeed = 12f;


    private enum MovementState { idle, running, jumping, falling };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        moveLeft = false;
        moveRight = false;
        jump = false;
    }
    public void PointerDownLeft()
    {
        moveLeft = true;
    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }
    public void PointerUpJump()
    {
        jump = false;
    }
    public void PointerDownJump()
    {
        jump = true;
    }
    // Update is called once per frame

    void Update()
    {
        MovementPlayer();
        Jump();
        UpdateAnimationState();

    }
    private void MovementPlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        }

        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }
    }
    public void Jump()
    {
        if (rb.velocity.y == 0 && jump == true)
        {
            isJump = true;
            JumpTimeCounter = jumping;
            rb.velocity = Vector2.up * jumpspeed;
        }
        if (jump == true && isJump == true)
        {
            if (JumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpspeed;
                JumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJump = false;
            }
        }
        if (jump == false)
        {
            isJump = false;
        }

    }



    private void UpdateAnimationState()
    {
        MovementState state;
        if (horizontalMove < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }

        else if (horizontalMove > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -1f)
        {
            state = MovementState.falling;
        }

        am.SetInteger("state", (int)state);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);
    }


}
