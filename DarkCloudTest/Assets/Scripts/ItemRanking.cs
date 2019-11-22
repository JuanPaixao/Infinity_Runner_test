using UnityEngine;
using UnityEngine.UI;

public class ItemRanking : MonoBehaviour
{
    [SerializeField] private Text positionText, nameText, scoreText; //Itens que estarão no ranking, a posição, o nome e a pontuação do jogador

    public void Configuration(int position, string nameText, int scoreText) //Método que define os valores que passarão ao jogador no ranking, é adicionado +1 a posição para que a posição
                                                                            //inicial não seja 0
    {
        position += 1;
        this.positionText.text = position.ToString() + "°";
        this.nameText.text = nameText;
        this.scoreText.text = scoreText.ToString();
    }
}
