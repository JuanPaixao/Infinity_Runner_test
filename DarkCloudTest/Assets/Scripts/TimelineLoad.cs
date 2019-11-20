using UnityEngine;
using UnityEngine.SceneManagement;

public class TimelineLoad : MonoBehaviour
{
    private void OnEnable()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
