using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
        _gameManager.isPaused = false;
        Time.timeScale = 1;
    }
    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
        _gameManager.isPaused = true;
        Time.timeScale = 0;
    }
}
