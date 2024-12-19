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
        enemycount = 0;
    }
    public void Checkforenemy()
    {
        enemycount--;
        if (enemycount == 0)
        {   
            if (VictoryMenu == null)
            {
                VictoryMenu = GameObject.Find("VictoryScreen");
            }
            VictoryMenu.SetActive(true);
            Time.timeScale = 0;

        }


    }

}
