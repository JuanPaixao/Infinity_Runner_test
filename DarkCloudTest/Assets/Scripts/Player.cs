using UnityEngine;

public class Player : MonoBehaviour
{
    public float movSpeed; //Componente responsável pela velocidade de movimento (vertical) do jogador
    public int HP; //Variável que seria responsável pela vida do jogador, caso o mesmo não fosse derrotado em um atauqe
    private GameManager _gameManager; //Compontente do GameManager para que o player utilize métodos dessa classe
    public Collider2D playerCollider; //Colisor do jogador, desativado quando está em pause para não conflitar com o colisor responsável pela troca de cores da roupa
    private UIManager _uiManager; //Gerenciador de interface
    private Animator _animator; //Animator responsável pela animação de morte
    public GameObject collisionScore; //Objeto responsável pela soma de pontos 

    private void Awake()
    {
        //Carregamento de referências 
        _gameManager = FindObjectOfType<GameManager>();
        _uiManager = FindObjectOfType<UIManager>();
        _animator = GetComponent<Animator>();
        // _uiManager.SetSliderBar(HP);
    }
    private void Update()
    {
        //Verificação de Input e movimentação a partir disso, com limites no eixo Y para que o jogador se mantenha na parte jogável
        float movVer = Input.GetAxisRaw("Vertical");
        this.transform.Translate(new Vector2(0, movVer * movSpeed * Time.deltaTime));
        if (this.transform.position.y >= -1.27f)
        {
            this.transform.position = new Vector2(this.transform.position.x, -1.27f);
        }
        if (this.transform.position.y <= -3.93f)
        {
            this.transform.position = new Vector2(this.transform.position.x, -3.93f);
        }
        //Desativação do colisor do jogador para que não tenha conflito com o colisor responsável pela troca de cor da armadura do jogador
        if (_gameManager.isPaused)
        {
            playerCollider.enabled = false;
        }
        else
        {
            playerCollider.enabled = true;
        }
    }
    public void TakeDamage() //Função responsável pelos comportamentos quando o jogador tomar dano, aonde está desativado a parte que funcionaria caso o jogador tivesse mais de 1 ponto de vida
                            //É desativado a colisão quando o jogador perde para que ele não possa ser atingido quando já perdeu, e também é desativado o colisor responsável pelos pontos.
    {
        //HP--;
        //   _uiManager.UpdateSliderBar(HP);
        _animator.SetTrigger("Death");
        playerCollider.enabled = false;
        collisionScore.SetActive(false);
    }
    public void Restart() //Função enviada ao gerenciador de jogo para carregar novamente a cena
    {
        _gameManager.LoadScene("Game");
    }
}
