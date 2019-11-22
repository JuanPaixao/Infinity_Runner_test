using UnityEngine;
using UnityEngine.SceneManagement;

public class TimelineLoad : MonoBehaviour
{
    //Objeto responsável pelo carregamento do menu ao ser ativado na introdução inicial
    private void OnEnable()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
