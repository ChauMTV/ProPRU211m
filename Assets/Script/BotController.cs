using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class BotController : MonoBehaviour
{
    public float walkSpeed = 2f;
    public bool moveRight = true;
    public Transform groundDetection;
    public LayerMask groundLayer;
    public Collider2D collider;
    void Update()
    {
        EnemyMovement();
    }
    void EnemyMovement()
    {
        transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, 2f);
        if (groundInfo.collider == false || collider.IsTouchingLayers(groundLayer))
        {
            if (moveRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                moveRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                moveRight = true;
            }
        }
    }

}
