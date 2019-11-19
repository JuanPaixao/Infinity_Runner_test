using UnityEngine;

public class Player : MonoBehaviour
{
    public float movSpeed;
    public int HP;
    private GameManager _gameManager;
    public Collider2D playerCollider;

    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
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
        if (_gameManager.isPaused)
        {
            playerCollider.enabled = false;
        }
        else
        {
            playerCollider.enabled = true;
        }
    }
    public void TakeDamage()
    {
        HP--;
    }
}
