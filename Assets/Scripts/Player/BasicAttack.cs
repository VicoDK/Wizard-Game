using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : MonoBehaviour
{

    [Header("Values")]
    public float Damage;
    public String itself;

    bool hit = false;
    public GameObject DestoyDetector;

    public Vector2 fireDIR;
    public float Speed;
    [SerializeField] private Rigidbody2D rb;

    private bool reflected;
    

    void Start()
    {
        Invoke("EnableDestoy", 0.04f);


    }

    //check if it hit anything and it is not the player
    public void OnTriggerEnter2D(Collider2D collision)
    {

        //here we check if it doesn't hit itself or a bullet or a wall 
        if(!collision.gameObject.CompareTag(itself) && !collision.gameObject.CompareTag("Bullet") && !collision.gameObject.CompareTag("Wall") && !collision.gameObject.CompareTag("DontHit")) 
        {
            Destroy(gameObject); //destroy ball
            //here we what it hits 
            if (itself == "Player")
            {
                EnemyStats enemyHealth = collision.GetComponent<EnemyStats>(); //take the health script
                if (enemyHealth != null && !hit) //if there is non do nothing
                {
                    hit = true;
                    enemyHealth.TakeDamage(Damage);
                }

                ShieldDamage(collision.gameObject);




   

            }
            else if (itself == "Enemy")
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();
                if (playerStats != null && !hit)
                {
                    hit = true;
                    playerStats.TakeDamage(Damage);
                }

                ShieldDamage(collision.gameObject);



            }
            
            
            

            
        }

        
    }

    void EnableDestoy()
    {
        DestoyDetector.SetActive(true);
    }

    

    public void DataTranfor(Vector2 fireDIRdt, float speedDT)
    {
        fireDIR = fireDIRdt;
        Speed = speedDT;

    }
    public void Reflect()
    {
        if (!reflected)
        {
            rb.AddForce(-fireDIR * Speed*2, ForceMode2D.Impulse);
            reflected = true;
        }
        

    }

    void ShieldDamage(GameObject Object)
    {
        if (Object.gameObject.CompareTag("Shield") && Object.GetComponent<ShieldDeteching>().shieldHealth>= 0)
        {
            Movment movement = GameObject.Find("Player2Body").GetComponent<Movment>();

            if (!movement.dashing)
            {

                Object.GetComponent<ShieldDeteching>().shieldHealth -= Damage;
                Object.GetComponent<ShieldDeteching>().regen = false;
                Destroy(gameObject); //destroy ball
            }
            else 
            {
                // do nothing

            }
        }
    }

}