using UnityEngine;
using UnityEngine.UI;

public class Enemytracker : MonoBehaviour
{
    public Text enemytracker;


    void Update()
    {
        enemytracker.text = "Enemy's left:" + GameManager.enemycount;
    }
}
