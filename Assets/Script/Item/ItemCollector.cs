using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    const int CoinPoints = 1;
    [SerializeField] private AudioSource collectionSoundEffect;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("coin"))
        {
            collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            
            HUD hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
            hud.AddCoin(CoinPoints);
           
        } 
    }
}
