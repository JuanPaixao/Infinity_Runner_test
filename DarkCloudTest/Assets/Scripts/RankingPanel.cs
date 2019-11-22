using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class RankingPanel : MonoBehaviour
{
    [SerializeField] private Ranking _ranking; //Referência ao Ranking
    [SerializeField] private GameObject _rankingItemPrefab;//Referência ao item do ranking (Cada item representa Posição - Jogador - Pontuação)

    private void Start()
    {
        UpdateRank(); // Atualiza o Ranking ao carregar a cena
    }
    public void UpdateRank() //Função responsável por carregar a cena quando a mesma for atualizada, sendo limitado por 5 itens no ranking, podendo ser alterado futuramente caso necessário
    {
        Clear();
        ReadOnlyCollection<PlayersOnRank> playerData = this._ranking.GetPlayersOnRank();

        for (int i = 0; i < playerData.Count; i++)
        {
            if (i >= 5)
            {
                break;
            }
            GameObject playerOnRanking = GameObject.Instantiate(this._rankingItemPrefab, this.transform);
            playerOnRanking.GetComponent<ItemRanking>().Configuration(i, playerData[i].name, playerData[i].score);
        }
    }
    public void Clear() //Função para limpar o ranking quando o mesmo for atualizado, para evitar dados sendo exibidos repetidamente e garantir a limpeza do ranking visualmente
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("RankItem");
        foreach (var item in obj)
        {
            Destroy(item);
        }
    }
}

