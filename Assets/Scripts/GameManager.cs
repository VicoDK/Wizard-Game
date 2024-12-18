using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public static int enemycount;
    public GameObject VictoryMenu;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    public void Checkforenemy()
    {
        enemycount--;
        if (enemycount == 0)
        {
            VictoryMenu.SetActive(true);
            Time.timeScale = 0;

        }


    }

}
