using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float projectileSpeed;
    private Animator _animator;
    private SpriteRenderer _sprite;
    private GameManager _gameManager;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _gameManager = FindObjectOfType<GameManager>();
        projectileSpeed = _gameManager.projectileSpawnedSpeed;
    }

    private void Update()
    {
        this.transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetTrigger("Destroyed");
            this.projectileSpeed = 0f;
            Player player = other.gameObject.GetComponent<Player>();
            player.TakeDamage();
            _sprite.sortingLayerName = "Player";
        }
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
