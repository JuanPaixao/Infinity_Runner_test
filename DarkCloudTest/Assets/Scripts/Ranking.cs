using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    private static string FILE_NAME = "ranking.json"; //Arquivo .json que será gerado com o ranking do jogador
    [SerializeField] private List<PlayersOnRank> playersOnRank; //Lista de jogadores do rank
    private string filePath;//Local em que o arquivo será salvo
    private void Awake()
    {
        //Verificação se já existe um arquivo no meu diretório específicado, se existir, é feito a leitura dos dados e então é sobrescrito, se não é então criado uma nova
        //Lista de PlayersOnRank
        this.filePath = Path.Combine(Application.persistentDataPath, FILE_NAME);
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
    public string AddScore(string name, int score) //Método responsável por adicionar jogadores na lista de jogadores do Rank, com um identificador único (Guid) 
                                                   //Sendo ordenadas de acordo com a pontuação
    {
        var id = Guid.NewGuid().ToString();
        PlayersOnRank playersOnRank = new PlayersOnRank(name, score, id);
        this.playersOnRank.Add(playersOnRank);
        this.playersOnRank.Sort();
        this.SaveRanking();
        return id;
    }
    public void SaveRanking() //Função responsável por salvar o ranking no arquivo .json
    {
        string jsonText = JsonUtility.ToJson(this, true); 
        File.WriteAllText(filePath, jsonText);
    }
    public int PlayersQuantity() //Retorna a quantidade de players que está na minha lista de players no ranking
    {
        return this.playersOnRank.Count;
    }
    public ReadOnlyCollection<PlayersOnRank> GetPlayersOnRank() //Retorna a minha lista de players do ranking em forma de leitura, evitando a manipulação forçada por meios externos de dados
    {
        return this.playersOnRank.AsReadOnly();
    }

    public void ChangeName(string newName, string id) //Método responsável por trocar o nome do jogador que será salvo no ranking, relacionando-o com a ID do jogador e então salvando o ranking
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
public class PlayersOnRank : IComparable //Classe com os dados que serão salvados no .json, com a interface ICOmparable para que possa ser possível a utilização do Sort()
                                        // Para ordernar os dados no ranking
{
    public string name;
    public int score;
    public string id;

    public PlayersOnRank(string name, int score, string id)
    {
        this.name = name;
        this.score = score;
        this.id = id;
    }

    public int CompareTo(object obj)
    {
        //menor que 0 antes de outro objeto, 0 se igual outro objeto, maior 0 se depois que outro objeto
        var otherObj = obj as PlayersOnRank;
        return otherObj.score.CompareTo(this.score);
    }
}