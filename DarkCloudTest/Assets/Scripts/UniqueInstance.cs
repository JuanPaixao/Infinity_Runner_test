using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueInstance : MonoBehaviour
{
    //Classe utilizada para garantir uma instância única do objeto, nesse caso, o responsável pela música, para que não tenha várias músicas iguais tocando ao mesmo tempo
    //Quando o jogador transicionar várias vezes entre o menu e a cena de jogo
    private void Start()
    {
        GameObject[] otherIntances = GameObject.FindGameObjectsWithTag(this.tag);
        foreach (var item in otherIntances)
        {
            if (item != this.gameObject)
            {
                Destroy(item);
            }
        }
    }
}
