using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
