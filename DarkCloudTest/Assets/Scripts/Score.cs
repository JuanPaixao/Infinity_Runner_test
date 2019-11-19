using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
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
