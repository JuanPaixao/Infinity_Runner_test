using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel;
    private GameManager _gameManager;
    public Text scoreText;
    public Slider slider;
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
    public void SetText(string text)
    {
        scoreText.text = text;
    }
    public void SetSliderBar(int hp)
    {
        if (slider != null)
        {
            slider.maxValue = hp;
            slider.value = hp;
        }
    }
    public void UpdateSliderBar(int hp)
    {
        slider.value = hp;
    }
}
