using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1.0f;
    }
    public void Play()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void MainMenu()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
