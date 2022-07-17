using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;

 

    //start destroy
    #region Fields

    [SerializeField]
    GameObject prefabExplosion;

<<<<<<< HEAD
    int damage = 100;
=======
    public int damage = 50;
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9

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

        Destroy(gameObject);
    }
    //end destroy 

   void Start()
    {
<<<<<<< HEAD
        rb.velocity = transform.right * speed;
=======
      
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9

    }

   

    // Update is called once per frame
    void Update()
    {

    }
<<<<<<< HEAD
=======
    public void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
}
