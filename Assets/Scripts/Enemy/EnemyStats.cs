using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float health;
    public void Stun()
    {
        Debug.Log("hello");
    }

    public void TakeDamage(float Damage)
    {
        health -= Damage;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}