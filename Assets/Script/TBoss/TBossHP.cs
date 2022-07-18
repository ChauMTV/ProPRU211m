using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TBossHP : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    public Vector3 offSet;

    public void setHP(float hp , float maxHp)
    {
        slider.gameObject.SetActive(hp < maxHp);
        slider.value = hp;
        slider.maxValue = maxHp;
        slider.fillRect.GetComponent<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }
    public void Update()
    {
        
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position+offSet);
    }
}
