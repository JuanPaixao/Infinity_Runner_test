using UnityEngine;
using UnityEngine.UI;

public class DynamicText : MonoBehaviour
{
    public Text textName, textScore; // texto referente ao nome que será adicionado ao rank e a pontuação que será adiconada ao rank
    private void Start()
    {
        //Atualizando os campos de nome e pontuação caso já possua algum valor salvo do jogador
        this.textName.text = PlayerPrefs.GetString("PlayerName", "Guest");
        this.textScore.text = PlayerPrefs.GetInt("MaxScore", 0).ToString();
    }
    public void UpdateName(string name)
    {
        //Atualizando o nome do campo textName que será adicionado ao rank juntamente com a pontuação,
        // e salvando o nome para utilizações futuras sem precisar digitar novamente
        this.textName.text = name;
        PlayerPrefs.SetString("PlayerName", name);
    }
    public void UpdateScore(int score)
    {
        //Atualizando texto de pontuação de acordo com o valor salvo. Quando a pontuação é salva, esse método é chamado para que
        //O valor atualize quando a pontuação estiver zerada novamente. (Ex: Jogador1 - 100 pontos, após dar upload dos pontos, sua pontuação vai para 0 e os 100 pontos para o ranking)
        this.textScore.text = PlayerPrefs.GetInt("MaxScore", 0).ToString();
    }
}
