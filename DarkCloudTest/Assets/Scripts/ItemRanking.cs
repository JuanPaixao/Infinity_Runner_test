using UnityEngine;
using UnityEngine.UI;

public class ItemRanking : MonoBehaviour
{
    [SerializeField] private Text positionText, nameText, scoreText;

    public void Configuration(int position, string nameText, int scoreText)
    {
        position += 1;
        this.positionText.text = position.ToString() + "°";
        this.nameText.text = nameText;
        this.scoreText.text = scoreText.ToString();
    }
}
