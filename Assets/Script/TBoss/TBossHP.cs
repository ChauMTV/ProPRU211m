using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TBossHP : MonoBehaviour
{
    public Slider slider;
    public Vector3 offSet;
    BulletScript bullet;


    public void setMaxHP(float Hp)
    {
        slider.maxValue = Hp;
        slider.value = Hp;
    }
    public void setHP(float Hp)
    {
        slider.value = Hp;
    }

    private void Awake()
    {
       slider.gameObject.SetActive(false);
    }
    public void Update()
    {
        if (bullet.isBossTakenDmg == true)
        {
            Debug.Log("A");

        }
        else
        {
            Debug.Log("B");
        }
    

        /* slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position+offSet);*/
        if (bullet.isBossTakenDmg == true)
        {
            slider.gameObject.SetActive(true);
        }

    }
}
