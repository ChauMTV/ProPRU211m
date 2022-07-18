using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossT : MonoBehaviour
{
	public Transform player;
	public float hp = 10;
	public bool isFlipped = false;
	public float HitPoint;
	public float MaxHitPoint = 5;
	public TBossHP hpBar;
	public Animator animator;

    public void Start()
    {
		HitPoint = MaxHitPoint;
		hpBar.setHP(HitPoint,MaxHitPoint);
    }

	public void TakeHit(float dmg)
    {
		hp -= dmg;
        HitPoint = dmg;
        hpBar.setHP(HitPoint, MaxHitPoint);
        if (hp < 0)
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
