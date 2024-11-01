using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ShieldDeteching : MonoBehaviour
{

    Movment Movment;
    
    // Start is called before the first frame update
    void Start()
    {
        Movment =  GameObject.Find("Player2Body").GetComponent<Movment>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (Movment.dashing && collision.CompareTag("Projectile"))
        {
           BasicAttack basicAttack = collision.GetComponent<BasicAttack>();

        
            // Check if the component exists before calling the Reflect method
            if (basicAttack != null)
            {

                basicAttack.Reflect(); // Call the Reflect method
            }
        }
        else if (Movment.dashing && collision.CompareTag("Enemy")) 
        {
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
        
            // Check if the component exists before calling the Reflect method
            if (enemyStats != null)
            {
                enemyStats.Stun(); // Call the Reflect method
            }


        }
        else if (collision.CompareTag("Projectile"))
        {
            Debug.Log("død");
            Destroy(collision.gameObject);
        }

    }
}
