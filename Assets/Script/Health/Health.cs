using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private float startingHealth;
    private Animator anim;
    private bool dead;   
    [SerializeField]
    Button btn;

    [Header("Iframe")]
    [SerializeField]
    private float IFrameDuration;
    [SerializeField]
    private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;
    public float currenHealth { get; private set; }
    // Start is called before the first frame update

    private void Awake()
    {
        currenHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    public void TakeDamage(float _damage)
    {
        currenHealth = Mathf.Clamp(currenHealth - _damage, 0, startingHealth);
        if (currenHealth > 0)
        {
            //hurt
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
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
                dead = true;
            }

        }if(currenHealth == 0)
        {
            SceneManager.LoadScene("GamoverScense");
        }
    }
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

    
}
