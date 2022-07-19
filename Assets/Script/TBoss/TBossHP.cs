using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TBossHP : MonoBehaviour
{
    public Slider slider;
    public Vector3 offSet;


    public void setMaxHP(float Hp)
    {
        slider.maxValue = Hp;
        slider.value = Hp;
    }
    public void setHP(float Hp)
    {
        slider.value = Hp;
    }
    public void Update()
    {
        
       /* slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position+offSet);*/
    }
}
