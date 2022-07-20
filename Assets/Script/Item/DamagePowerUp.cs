using UnityEngine;

public class DamagePowerUp : MonoBehaviour
{
    //bool for check when player collide with item powerup
    public bool activated;
    [SerializeField] private AudioSource powerUpSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            powerUpSoundEffect.Play();
            GameObject player = collision.gameObject;
            //change the weapon to instantiate a poweredup bullet
            Weapon bullet = player.GetComponent<Weapon>();
            activated = true;
            bullet.isPoweredUp = activated;
            Destroy(gameObject);

        
        }
       

    }
}
