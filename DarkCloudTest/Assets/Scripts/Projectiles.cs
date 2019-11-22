using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float projectileSpeed; //Velocidade do projétil, definida a partir da velocidade inicial e do tempo que o jogador está vivo, acelerando com o tempo
    private Animator _animator; //Responsável pela animação do projétil
    private SpriteRenderer _sprite; //Responsável pelo sprite do projétil
    private GameManager _gameManager; //Gerenciador de jogo
    public GameObject explosionSound; //Objeto que será instanciado quando o objeto explodir ao tocar no jogador

    private void Awake()
    {
        //Obtendo os compontentes necessários
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _gameManager = FindObjectOfType<GameManager>();
        projectileSpeed = _gameManager.projectileSpawnedSpeed;
    }

    private void Update()
    {
        this.transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime); //Movimentação semrpe para a direita, de acordo com a velocidade do projétil
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Ao entrar em contato com o jogador, é criado um objeto responsável pelo som de forma independente, para que quando esse objeto
        //For destruído, o som não seja cortado pela metade mesmo sem ter terminado. A animação responsável pela explosão é acionada e
        //O projétil para de se mover, o Player recebe o dano e a camada da sortingLayer é alterada para a do jogador par aque a explosão
        //Fique sempre em cima do jogador, já o jogador não tem colisão em toda sua cabeça já que ele está em pé, possibilitando que o 
        //Projétil passe por trás de sua cabeça, essa ação foi necessária para que não ocorra explosões com comportamentos estranhos
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(explosionSound);
            _animator.SetTrigger("Destroyed");
            this.projectileSpeed = 0f;
            Player player = other.gameObject.GetComponent<Player>();
            player.TakeDamage();
            _sprite.sortingLayerName = "Player";
        }
    }
    public void Destroy() //Destruir o projétil, chamado quando a animação de explosão finalizar
    {
        Destroy(this.gameObject);
    }
}
