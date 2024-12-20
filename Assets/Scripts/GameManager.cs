using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public static int enemycount;
    public  GameObject victoryMenu;
    public static GameObject VictoryMenu;

    private void Awake()
    {
        VictoryMenu = victoryMenu;
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        enemycount = 0;
    }
    public void Checkforenemy()
    {
        enemycount--;
        if (enemycount <= 0)
        {   

            VictoryMenu.SetActive(true);
            Time.timeScale = 0;

        }


    }



}
