using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    //Script unicamente destinado a não destruição do objeto ao carregar uma cena nova, no caso, usado para o reprodutor de sons.
    private void Awake()
    {
       DontDestroyOnLoad(this.gameObject);
    }
}
