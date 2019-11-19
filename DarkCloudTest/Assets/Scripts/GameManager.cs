using UnityEngine;

public class GameManager : MonoBehaviour
{
    public string color;
    public int weapon;
    public ProjectileSpawner projectileSpawner;
    public bool isGameScene;
    public float time, spawnTime, currentSpawnTime, difficultyTime, projectileSpawnedSpeed, maxProjectileSpeed, minSpawnTime;
    private UIManager _uiManager;
    public bool isPaused;
    public int score;
    private void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        currentSpawnTime = spawnTime;
    }
    private void Update()
    {
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
    public void SetColor(string color)
    {
        this.color = color;
    }
    public void SetWeapon(int weaponNumber)
    {
        this.weapon = weaponNumber;
    }
    public string ReturnColor()
    {
        return this.color;
    }
    public int ReturnWeapon()
    {
        return this.weapon;
    }
    public void AddScore()
    {
        score++;
    }
}
