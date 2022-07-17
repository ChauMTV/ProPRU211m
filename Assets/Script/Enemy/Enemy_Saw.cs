using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Saw : MonoBehaviour
{
    [SerializeField]
<<<<<<< HEAD
    private float damage;
   
=======
    private float movementDistance;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;
   private bool movingLeft;
    private float LeftEdge; 
    private float RightEdge;

    private void Awake()
    {
        LeftEdge = transform.position.x - movementDistance;

        RightEdge = transform.position.x + movementDistance;
    }

>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag =="Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
    private void Update()
    {
<<<<<<< HEAD
=======
        if (movingLeft)
        {
            if (transform.position.x >LeftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, 
                    transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < RightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, 
                    transform.position.y, transform.position.z);
            }
            else
            {
                movingLeft=true;
            }
        }
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
        
    }

}
