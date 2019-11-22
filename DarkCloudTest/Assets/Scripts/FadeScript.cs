using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    //Função para desativar o objeto responsável pelo fade out
    public void SetFadeInactive()
    {
        this.gameObject.SetActive(false);
    }
}
