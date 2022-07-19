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

    public void Start()
    {
		currentHp = MaxHp;
		hpBar.setMaxHP(MaxHp);
    }

	public void TakeHit(float dmg)
    {

        currentHp -= dmg;
        hpBar.setHP(currentHp);
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
