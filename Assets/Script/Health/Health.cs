using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
<<<<<<< HEAD
=======
    [Header("Health")]
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
    [SerializeField]
    private float startingHealth;
    private Animator anim;
    private bool dead;
    [SerializeField]
    Button btn;
<<<<<<< HEAD
=======

    [Header("Iframe")]
    [SerializeField]
    private float IFrameDuration;
    [SerializeField]
    private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
    public float currenHealth { get; private set; }
    // Start is called before the first frame update

    private void Awake()
    {
        currenHealth = startingHealth;
        anim = GetComponent<Animator>();
<<<<<<< HEAD
=======
        spriteRenderer = GetComponent<SpriteRenderer>();
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
    }
    public void TakeDamage(float _damage)
    {
        currenHealth = Mathf.Clamp(currenHealth - _damage, 0, startingHealth);
        if (currenHealth > 0)
        {
            //hurt
            anim.SetTrigger("hurt");
<<<<<<< HEAD
=======
            StartCoroutine(Invunerability());
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
            //iframe

        }
        else
        {
            //die
            if (!dead)
            {
                anim.SetTrigger("die");
                GetComponent<CharacterMovement>().enabled = false;
                GetComponent<Weapon>().enabled = false;
<<<<<<< HEAD
                //GetComponent<Canvas>().enabled=false;
                ////GetComponent<CharacterMovement>().onclick
                //btn = GetComponent<Button>();
                //btn.gameObject.SetActive(false);
                //btn.interactable = false;
=======
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
                dead = true;
            }

        }
    }
<<<<<<< HEAD
=======
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11,true);
        //thoi gian bat tu 
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(IFrameDuration/(numberOfFlashes*2));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(IFrameDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
>>>>>>> 9fe49f0ac3065a8b929536894e187a0afdb251b9
}
