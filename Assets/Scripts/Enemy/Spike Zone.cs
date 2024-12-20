using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpikeZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("Values")]
    public float Damage;
    public bool on = false;


    public SpriteRenderer sr;
    public Sprite spike;
        private bool AttackReady = true;


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                EnemyStats enemyHealth = collision.GetComponent<EnemyStats>(); //take the health script
                if (enemyHealth != null && on && AttackReady) //if there is non do nothing
                {
                    
                    enemyHealth.TakeDamage(Damage);
                    StartCoroutine(Attacks());
                }

                //ShieldDamage(collision.gameObject);






            }
            else if (collision.gameObject.CompareTag("Player"))
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();
                if (playerStats != null && on && AttackReady)
                {
                    
                    playerStats.TakeDamage(Damage);
                    StartCoroutine(Attacks());
                }

                //ShieldDamage(collision.gameObject);



            }



        }








    }
    void ShieldDamage(GameObject Object)
{
    if (Object.gameObject.CompareTag("Shield") && Object.GetComponent<ShieldDeteching>().shieldHealth >= 0)
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



    public void Turnon()
    {
        StartCoroutine(TurnOn());
    }

    public IEnumerator TurnOn()
    {
        on = false;
        yield return new WaitForSeconds(1f);
        on = true;
        sr.sprite = spike;
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }

    private IEnumerator Attacks ()
    {
        //here we set attack ready to false so we can't attack again
        AttackReady = false;
        //here we wait some seconds
        yield return new WaitForSeconds(0.5f);
        //here we set attack ready to true so we can attack again
        AttackReady = true;
        
    }
}
