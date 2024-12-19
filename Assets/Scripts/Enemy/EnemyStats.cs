using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    public float health;
    private float MaxHealth;
    public bool Alive;
    public Image HealthBar;

    void  Start()
    {
        MaxHealth = health;
        GameManager.enemycount++;
    }
    public void smite()
    {
        health /=2;
    }

    public void TakeDamage(float Damage)
    {
        health -= Damage;
    }

    void Update()
    {
        if (health <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().Checkforenemy();
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        HealthBar.fillAmount = health / MaxHealth;

    }
}
