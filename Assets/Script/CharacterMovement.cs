using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.CrossPlatformInput;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator am;
    private SpriteRenderer sprite;
<<<<<<< HEAD
    private float horizontalMove;
=======
    public float horizontalMove;
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
    bool isRolling;
    bool canRoll = true;
    private float rollDir = 1;
    private float rollingTime = 0.4f;
    private float rollingCoolDown = 1f;
    public float JumpTimerCounter;
    public float jumpTime;
    private bool isJump;
    private float jump = 0;
<<<<<<< HEAD


    [SerializeField] private float speed = 7f;
=======
    [HideInInspector] public bool isRight = true;


    [SerializeField] public float speed = 7f;
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
    [SerializeField] private float rollingSpeed = 21f;
    [SerializeField] private float jumpspeed = 12f;

    private enum MovementState { idle, running, jumping, falling, rolling };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame

    void Update()
    {
        if (horizontalMove != 0)
        {
            rollDir = horizontalMove;
        }
        horizontalMove = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        jump = CrossPlatformInputManager.GetAxisRaw("Vertical");
        Jump(jump);
        if (CrossPlatformInputManager.GetButtonDown("Roll") && canRoll == true && rb.velocity.y == 0)
        {
            if (Roll() != null)
            {
                StopCoroutine(Roll());
            }
            StartCoroutine(Roll());
        }
        UpdateAnimationState();
    }

    public float Jump( float jump)
    {
        if (rb.velocity.y == 0 && jump > 0)
        {
            isJump = true;
            JumpTimerCounter = jumpTime;
            rb.velocity = Vector2.up * jumpspeed;
        }
        if (jump > 0 && isJump == true)
        {
            if (JumpTimerCounter > 0)
            {
                rb.velocity = Vector2.up * jumpspeed;
                JumpTimerCounter -= Time.deltaTime;
            }
            else
            {
                isJump = false;
            }
        }
        else if (jump == 0)
        {
            isJump = false;
        }
        return 1;
    }

    private IEnumerator Roll()
    {
        isRolling = true;
        canRoll = false;
        yield return new WaitForSeconds(rollingTime);
        isRolling = false;
        yield return new WaitForSeconds(rollingCoolDown);
        canRoll = true;
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (isRolling)
        {
            if (rollDir < 0 && rb.velocity.x < 0f)
            {
                state = MovementState.rolling;
                sprite.flipX = true;
            }
            else if (rollDir > 0 && rb.velocity.x > 0f)
            {
                state = MovementState.rolling;
                sprite.flipX = false;
            }
            else
            {
                state = MovementState.idle;
            }
            am.SetInteger("state", (int)state);
        }
        else
        {

            if (horizontalMove < 0f)
            {
<<<<<<< HEAD
                state = MovementState.running;
                sprite.flipX = true;
=======
                
                isRight = false;
                state = MovementState.running;
                sprite.flipX = true;

>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
            }

            else if (horizontalMove > 0f)
            {
<<<<<<< HEAD
=======
                
                isRight = true;
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
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
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
<<<<<<< HEAD
=======

       
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
        if (isRolling)
        {
            rb.AddForce(new Vector2(rollDir * rollingSpeed, 0), ForceMode2D.Impulse);
        }
    }
}
