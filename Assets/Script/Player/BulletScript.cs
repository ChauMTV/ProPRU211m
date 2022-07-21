using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public bool isBossTakenDmg;





    //start destroy
    #region Fields

    [SerializeField]
    GameObject prefabExplosion;

    public int damage = 50;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the damage the fish inflicts
    /// </summary>
    public int Damage
    {
        get { return damage; }
    }

    #endregion

    #region Methods


    /// <summary>
    /// Destroy moster on collision
    /// </summary>
    /// <param name="collision">collision info</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {   
        if (collision.gameObject.CompareTag("monster"))
        {
            Instantiate<GameObject>(prefabExplosion,
                transform.position, Quaternion.identity);
           
            Destroy(gameObject);

        }
        Destroy(gameObject);
    }
    /// <summary>
    /// Destroy when leave game
    /// </summary>
    void OnBecameInvisible()
    {

        Destroy(gameObject);
    }

    #endregion
  private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.CompareTag("TBoss"))
        {
 
            collision.GetComponent<BossT>().TakeHit(1);
            isBossTakenDmg = true;

        }
        if (!collision.gameObject.CompareTag("FireBall"))
        {
            Destroy(gameObject);
        }
       
    }

    //end destroy 

    public void Awake()
    {

        isBossTakenDmg = false;
    }

   

    // Update is called once per frame
    void Update()
    {

    }
    public void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }
}
