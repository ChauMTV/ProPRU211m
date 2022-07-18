using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiobackground : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
