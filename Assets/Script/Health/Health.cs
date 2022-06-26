using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float startingHealth;
    private Animator anim;

    public float currenHealth { get; private set; }
    // Start is called before the first frame update

    private void Awake()
    {
        currenHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currenHealth = Mathf.Clamp(currenHealth-_damage, 0, startingHealth);
        if (currenHealth > 0)
        {
            //hurt
            anim.SetTrigger("hurt");
        }
        else
        {
            //die
            anim.SetTrigger("die");
        }
    }
}
