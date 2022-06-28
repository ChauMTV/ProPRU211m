using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float startingHealth;
    private Animator anim;
    private bool dead;
    [SerializeField]
    Button btn;
    public float currenHealth { get; private set; }
    // Start is called before the first frame update

    private void Awake()
    {
        currenHealth = startingHealth;
        anim = GetComponent<Animator>();
    }
    public void TakeDamage(float _damage)
    {
        currenHealth = Mathf.Clamp(currenHealth - _damage, 0, startingHealth);
        if (currenHealth > 0)
        {
            //hurt
            anim.SetTrigger("hurt");
            //iframe

        }
        else
        {
            //die
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<CharacterMovement>().enabled = false;
                //GetComponent<Canvas>().enabled=false;
                ////GetComponent<CharacterMovement>().onclick
                //btn = GetComponent<Button>();
                //btn.gameObject.SetActive(false);
                //btn.interactable = false;
                dead = true;
            }

        }
    }
}
