using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject pausePanel; //Menu de pausa, ativado quando o jogador pausar o jogo
    private GameManager _gameManager; //Gerenciador de jogo
    public Text scoreText; //Texto responsável pela pontuação
    public Slider slider; //Slider, caso o jogador utilize mais de um ponto de vida, podendo ser alterado futuramente
    private void Awake() //Pegando as referências
    {
        _gameManager = FindObjectOfType<GameManager>(); 
    }

    public void ClosePausePanel() //Fechando menu de pause, então desativando-o e despausando o jogo
    {
        pausePanel.SetActive(false);
        _gameManager.isPaused = false;
        Time.timeScale = 1;
    }
    public void OpenPausePanel() //Abrindo menu de pause, pausando o jogo e ativando o painel que permite a troca de cores ou navegação entre as cenas
    {
        pausePanel.SetActive(true);
        _gameManager.isPaused = true;
        Time.timeScale = 0;
    }
    public void SetText(string text) //Setando o texto da pontuação do jogador
    {
        scoreText.text = text;
    }
    public void SetSliderBar(int hp) //Caso utilizado futuramente, relacionando a vida máxima do jogador com sua barra de vida
    {
        if (slider != null)
        {
            slider.maxValue = hp;
            slider.value = hp;
        }
    }
    public void UpdateSliderBar(int hp) //Caso utilizado futuramente, relacionando o valor atual da barra de vida do jogador com sua vida atual
    {
        slider.value = hp;
    }
}
