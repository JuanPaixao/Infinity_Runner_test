using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string color; //Cor armazenada ao selecionar objeto de troca de cor do personagem para então poder pintar as peças da armadura e o cabelo do personagem
    public int weapon; //Número da arma armazenado ao seleciona-la para que se possa fazer a troca da arma do personagem
    public ProjectileSpawner projectileSpawner; //Objeto responsável pelo spawn dos projéteis no gameplay
    public bool isGameScene; //Booleana verificando se é a cena em que se passa o gameplay em si ou não
    public float spawnTime, currentSpawnTime, difficultyTime, projectileSpawnedSpeed, maxProjectileSpeed, minSpawnTime; //Variáveis responsáveis por ajustes de tempo de spawn/dificuldade
                                                                                                                        //velocidade dos projéteis, tempo mínimo de spawn e velocidade máxima do projétil 

    private UIManager _uiManager; //Objeto responsável pelo controle de objetos de UI
    public bool isPaused; //Booleana verificando se está em pause
    public int score; //Pontuação
    public Ranking ranking; //Objeto responsável pelo ranking
    private string id; //ID do player que será adicionado ao ranking
    private int lastScore; //Responsável pela última pontuação/pontuação máxima registrada que ainda não foi colocada no ranking
    public bool isRankingScreen;//Booleana que verifica se está na tela de ranking
    private void Start()
    {
        //Obtendo componentes, assegurando que não está em pausa (se estiver, resumir) e igualando o tempo de spawn atual para o tempo de spawn padrão
        _uiManager = FindObjectOfType<UIManager>();
        currentSpawnTime = spawnTime;
        Time.timeScale = 1;
    }
    private void Update()
    {
        //Verifica se é o jogo para que o tempo de spawn possa começar a ser subtraído e assim começar a criar elementos (bolas de fogo no caso) para o jogador desviar
        //É feito o spawn e então um constante ajuste de velocidade do projétil/tempo de spawn em relação ao tempo que a dificuldade será alterada
        //Mantendo o controle de valores mínimos e máximos para que não fique impossível (tempo mínimo de spawn, velocidade máxima dos projéteis)
        if (isGameScene)
        {
            currentSpawnTime -= Time.deltaTime;

            if (currentSpawnTime <= 0)
            {
                projectileSpawner.Spawn();
                spawnTime -= difficultyTime;
                projectileSpawnedSpeed += difficultyTime;
                if (spawnTime <= minSpawnTime)
                {
                    spawnTime = minSpawnTime;
                }
                if (projectileSpawnedSpeed >= maxProjectileSpeed)
                {
                    projectileSpawnedSpeed = maxProjectileSpeed;
                }
                currentSpawnTime = spawnTime;
            }
            //Sistema de Pause, responsável por pausar o jogo e abrir o menu de pause tanto para a troca de cores do player ingame tanto para voltar ao menu principal
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
            {
                if (!isPaused)
                {
                    _uiManager.OpenPausePanel();
                }
                else
                {
                    _uiManager.ClosePausePanel();
                }
            }
        }
    }
    public void SetColor(string color) //Método responsável por definir a cor de acordo com o botão da cor clicado
    {
        this.color = color;
    }
    public void SetWeapon(int weaponNumber)//Método responsável por definir a arma de acordo com o botão da arma clicado
    {
        this.weapon = weaponNumber;
    }
    public string ReturnColor() //Método responsável por retornar ao script responsável pela troca de cor do jogador a cor que está selecionada
    {
        return this.color;
    }
    public int ReturnWeapon() //Método responsável por retornar ao script responsável pela troca da arma do jogador a arma que está selecionada
    {
        return this.weapon;
    }
    public void AddScore() //Adicionar a pontuação internamente do jogador, e atualizar na UI o valor do mesmo. Se o valor atual for maior que o último valor salvo, 
                           //O último valor salvo é sobrescrito e salvo
    {
        score++;
        _uiManager.SetText("Score: " + score.ToString());
        if (score > lastScore)
        {
            lastScore = score;
            PlayerPrefs.SetInt("MaxScore", lastScore);
        }
    }
    public void AddToRanking() //Responsável por receber o nome e o valor da pontuação que está salvo como pontuação máxima, e se a pontuação for diferente de 0
                               //Então esses dados serão adicionados ao Ranking de jogadores, e o valor máximo então retornará a 0 para evitar que o mesmo jogador
                               //Possa entrar várias vezes no ranking com a mesma pontuação
    {
        int tempMaxScore = PlayerPrefs.GetInt("MaxScore", 0);
        if (tempMaxScore > 0)
        {
            this.id = this.ranking.AddScore(PlayerPrefs.GetString("PlayerName", "Guest"), tempMaxScore);
            FindObjectOfType<RankingPanel>().UpdateRank();
            PlayerPrefs.SetInt("MaxScore", 0);
            FindObjectOfType<DynamicText>().UpdateScore(0);
        }
    }
    public void ChangeName(string name) //Método para a troca de nome que será adicionado ao ranking, que está sendo chamado do script do Ranking em si
    {
        this.ranking.ChangeName(name, this.id);
    }
    public void LoadScene(string sceneName) //Método responsável por carregar cenas
    {
        SceneManager.LoadScene(sceneName);
    }
}
