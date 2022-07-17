using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
<<<<<<< HEAD

    public Transform GunPoint;
    public GameObject bulletPrefab;
    public int gunPower = 1;


    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {

        Instantiate(bulletPrefab, GunPoint.position, GunPoint.rotation);

=======
    public float fireRate = 0.2f;
    public Transform GunPoint;
    public GameObject bulletPrefab;
    public GameObject pBulletPrefab;
    public GameObject powerupBullet;
    public GameObject currentBullet;
    private bool direction;
    public bool isPoweredUp=false;
     float timeUntilFire;

     CharacterMovement playerdirection;

    private void Start()
    {
        playerdirection = gameObject.GetComponent<CharacterMovement>();
        direction = true;
        currentBullet = bulletPrefab;

        powerupBullet = pBulletPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        direction = playerdirection.isRight;
        if (direction==true)
        {
            GunPoint.localPosition = new Vector3(0.8f, -0.5f, 0);
        }
        if (direction==false)
        {
            GunPoint.localPosition = new Vector3(-0.8f, -0.5f, 0);
        }
    }

    void Shoot()
    {

        float angle = playerdirection.isRight ? 0f : 180f;
        
        if (timeUntilFire < Time.time)
        {
            if (isPoweredUp == false)
            {
                Instantiate(currentBullet, GunPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
            }
            if (isPoweredUp == true)
            {
                Instantiate(powerupBullet, GunPoint.position, Quaternion.Euler(new Vector3(0f, 0f, angle)));
            }
            timeUntilFire = Time.time + fireRate;
        }
   
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9

    }

}

