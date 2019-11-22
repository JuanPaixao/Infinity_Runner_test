using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    private static string FILE_NAME = "ranking.json";
    [SerializeField] private List<PlayersOnRank> playersOnRank;
    private string filePath;
    private void Awake()
    {
        this.filePath = Path.Combine(Application.persistentDataPath, FILE_NAME); //my file path
        if (File.Exists(filePath))
        {
            string jsonText = File.ReadAllText(this.filePath);
            JsonUtility.FromJsonOverwrite(jsonText, this);
        }
        else
        {
            this.playersOnRank = new List<PlayersOnRank>();
        }
    }
    public int AddScore(string name, int score)
    {
        var id = this.playersOnRank.Count * UnityEngine.Random.Range(1, 10000);
        PlayersOnRank playersOnRank = new PlayersOnRank(name, score, id);
        this.playersOnRank.Add(playersOnRank);
        this.SaveRanking();
        return id;
    }
    public void SaveRanking()
    {
        string jsonText = JsonUtility.ToJson(this, true); //send my whole class to this jsonText file
        File.WriteAllText(filePath, jsonText);//write my path and its content
    }
    public int PlayersQuantity()
    {
        return this.playersOnRank.Count;
    }
    public ReadOnlyCollection<PlayersOnRank> GetPlayersOnRank()
    {
        return this.playersOnRank.AsReadOnly();
    }

    public void ChangeName(string newName, int id)
    {
        foreach (var players in playersOnRank)
        {
            if (players.id == id)
            {
                players.name = newName;
                break;
            }
        }
        this.SaveRanking();
    }
}
[System.Serializable] //permitir que os dados sejam salvos
public class PlayersOnRank
{
    public string name;
    public int score;
    public int id;

    public PlayersOnRank(string name, int score, int id)
    {
        this.name = name;
        this.score = score;
        this.id = id;
    }
}