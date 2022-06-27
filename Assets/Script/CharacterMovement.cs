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
    private float horizontalMove;
    bool isRolling;
    bool canRoll =true;
    private float rollDir = 1;
    private float rollingTime = 0.4f;
    private float rollingCoolDown = 1f;

    [SerializeField] private float speed = 7f;
    [SerializeField] private float rollingSpeed = 21f;
    [SerializeField] private float jumpspeed = 12f;

    private enum MovementState {idle, running, jumping, falling ,rolling};

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
        
        if (CrossPlatformInputManager.GetButtonDown("Roll") && canRoll == true && rb.velocity.y ==0)
        {
            if (Roll() != null)
            {
                StopCoroutine(Roll());
            }
            StartCoroutine(Roll());
        }
        UpdateAnimationState();
    }

    public void Jump()
    {
        if (rb.velocity.y == 0)
        {
            rb.velocity = Vector2.up * jumpspeed;
        }
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
            if(rollDir < 0 && rb.velocity.x < 0f)
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
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove * speed, rb.velocity.y);
        if (isRolling)
        {
            rb.AddForce(new Vector2(rollDir * rollingSpeed, 0), ForceMode2D.Impulse);
        }
    }
}
