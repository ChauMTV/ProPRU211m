using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public Transform GunPoint;
    public GameObject bulletPrefab;
    public int gunPower=10 ;


    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {

        Instantiate(bulletPrefab, GunPoint.position, GunPoint.rotation);


    }

  
}

