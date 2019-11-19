using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile;

    public void Spawn()
    {
        float randomSpawnPos = Random.Range(-4.56f, -2.30f);
        Instantiate(projectile, new Vector2(this.transform.position.x, randomSpawnPos), Quaternion.identity);
    }
}
