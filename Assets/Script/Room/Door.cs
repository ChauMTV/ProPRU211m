using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Transform inDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (collision.transform.position.x <transform.position.x)
            {
                inDoor.GetComponent<Botreset>().ActivationBot(false);
            }
            else
            {
                inDoor.GetComponent<Botreset>().ActivationBot(true);    
            }
        }    
    }


}
