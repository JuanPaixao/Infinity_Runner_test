using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    //Classe responsável por avisar para o gerenciador de jogo quando um projétil já "passou" pelo jogador em seu detector de pontos e assim, pontuar
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            _gameManager.AddScore();
        }
    }
}
