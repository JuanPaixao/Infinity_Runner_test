using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject projectile; //Objeto a ser instanciado

    public void Spawn() //Função responsável por instanciar o objeto, da menor posição possível do Y até a maior posição possível do Y de forma aleatória
    {
        float randomSpawnPos = Random.Range(-4.56f, -2.30f);
        Instantiate(projectile, new Vector2(this.transform.position.x, randomSpawnPos), Quaternion.identity);
    }
}
