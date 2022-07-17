using UnityEngine;

public class DamagePowerUp : MonoBehaviour
{
    //bool for check when player collide with item powerup
    public bool activated;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            GameObject player = collision.gameObject;
            //change the weapon to instantiate a poweredup bullet
            Weapon bullet = player.GetComponent<Weapon>();
            activated = true;
            bullet.isPoweredUp = activated;
            Destroy(gameObject);

            //foreach(GameObject bl in bullet)
            //{
            //    bl.GetComponent<BulletScript>().damage += increase;
            //}

            //GameObject player = collision.gameObject;
            //Weapon bullet = player.GetComponent<BulletScript>

            //if (bullet)
            //{
            //    bullet.GetComponent<BulletScript>().damage += increase;
            //    Destroy(gameObject);
            //}
        }
        //if (collision.tag == "Player")
        //{
        //    GameObject player = collision.gameObject;
        //    CharacterMovement move = player.GetComponent<CharacterMovement>();

        //    if (move)
        //    {
        //        move.speed += increase;
        //        Destroy(gameObject);
        //    }
        //}

    }
}
