using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossT : MonoBehaviour
{
	public Transform player;
	public bool isFlipped = false;
	public float currentHp;
	public float MaxHp = 10;
	public TBossHP hpBar;
	public Animator animator;
	[SerializeField]
	GameObject fireBall;
/*	float fireRate = 2f;
	float nextFire;*/
	public Transform BossFirePoint;
	public bool isdizzy = false;

    public void Start()
    {
		currentHp = MaxHp;
		hpBar.setMaxHP(MaxHp);
/*		nextFire = Time.time;*/
    }

    public void Update()
    {
    }

	public void TimeToFire()
    {
/*		if(Time.time > nextFire  && animator.Equals("range"))
        {*/
			Instantiate(fireBall,BossFirePoint.position, BossFirePoint.rotation);
/*			nextFire = Time.time + fireRate;*/
  /*      }*/
    }


	public void TakeHit(float dmg)
    {
        if (isdizzy)
        {
			return;
        }
        currentHp -= dmg;
        hpBar.setHP(currentHp);
		if(currentHp <= 5)
        {
			animator.SetTrigger("dizzy");
        }
        if (currentHp <= 0)
        {
			animator.SetTrigger("die");
			
		}
    }

	public void Deactive()
    {
		gameObject.SetActive(false);
    }

    public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}
}
