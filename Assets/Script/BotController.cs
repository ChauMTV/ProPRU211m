using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class BotController : MonoBehaviour
{
    public float walkSpeed;
    [HideInInspector]
    public bool mustPatrol;
    public bool mustTurn;

    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodyCollider;

    private BoxCollider2D coll;


    //Chasing player part
    public GameObject player;
    private Transform playerPos;
    private Vector2 cunrrentPos;
    public float distance;
    public float speedBot;
    private Animation botAnim;



    private void Awake()
    {


    }


    // Start is called before the first frame update
    void Start()
    {
        mustPatrol = true;

        //Chasing player part
        playerPos = player.GetComponent<Transform>();
        cunrrentPos = GetComponent<Transform>().position;
        botAnim = GetComponent<Animation>();




    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }

        //Chasing player part
        if (Vector2.Distance(transform.position, playerPos.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speedBot + Time.deltaTime);
            mustPatrol = true;
        }
        else
        {
            if (Vector2.Distance(transform.position, cunrrentPos) <= 0)
            {
                mustPatrol = false;
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, cunrrentPos, speedBot * Time.deltaTime);
                mustPatrol = true;
            }

        }

    }

    private void FixedUpdate()
    {

        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);

        }


    }
    void Patrol()
    {
        if (mustPatrol || bodyCollider.IsTouchingLayers(groundLayer))
        {
            Flip();

        }
        rb.velocity = new Vector2(walkSpeed * Time.deltaTime, rb.velocity.y);

    }

    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;


    }

}




