using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void GameRestart()
    {
        SceneManager.LoadScene(0);
    }
}
