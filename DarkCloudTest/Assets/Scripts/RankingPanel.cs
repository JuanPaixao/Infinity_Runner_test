using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class RankingPanel : MonoBehaviour
{
    [SerializeField] private Ranking _ranking;
    [SerializeField] private GameObject _rankingItemPrefab;

    private void Start()
    {
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
}
