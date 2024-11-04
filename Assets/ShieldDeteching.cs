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
        /*while (Movment.dashing)
        {
            string tag = collision.tag;
            switch (tag)
            {
                case "Projectile":
                BasicAttack basicAttack = collision.GetComponent<BasicAttack>();
        
                // Check if the component exists before calling the Reflect method
                if (basicAttack != null)
                {

                    basicAttack.Reflect(); // Call the Reflect method
                }
                break;

                case "Enemy":
                EnemyMovement enemyStats = collision.GetComponent<EnemyMovement>();
        
                // Check if the component exists before calling the Reflect method
                Debug.Log("stunned");
                enemyStats.Stun(); // Call the Reflect method
                
                break;

            }




        }*/
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
            EnemyMovement enemyStats = collision.GetComponent<EnemyMovement>();
        
            // Check if the component exists before calling the Reflect method
 
            Debug.Log("stunned");
            enemyStats.Stun(); // Call the Reflect method
            


        }
        

    }
}
