using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class ShieldDeteching : MonoBehaviour
{

    Movment Movment;
    public float shieldHealth;
    private float maxShieldHealth;
    private float shieldSize;
    private float startShieldSizeX;
    private float startShieldSizeY;
    public float regenAmount;
    public bool regen;
    public float regenStartTimer;
    private bool died;
    public float diedTimer;
    private bool ones;
    private float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        Movment =  GameObject.Find("Player2Body").GetComponent<Movment>();
        maxShieldHealth = shieldHealth;
        startShieldSizeX = transform.localScale.x;
        startShieldSizeY = transform.localScale.y;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            regen = true;
        }

        shieldSize = shieldHealth/maxShieldHealth;
        transform.localScale = new Vector3(shieldSize*startShieldSizeX, startShieldSizeY, 1);

        if (shieldHealth < 0)
        {
            died = true;
            Invoke("Revive", diedTimer);
        }

        

        



    }

    void FixedUpdate()
    {

        if (!died && regen && shieldHealth <= maxShieldHealth)
        {
            shieldHealth += regenAmount;
        }
        else if (!regen && ones)
        {
            ones = false;
            timer = regenStartTimer;
            
        }

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
            AIAgent enemyMovement = collision.GetComponent<AIAgent>();
            EnemyStats enemyStats = collision.GetComponent<EnemyStats>();
            // Check if the component exists before calling the Reflect method
 
            enemyStats.smite();
            enemyMovement.Stun(); // Call the Reflect method

            


        }
        

    }
    
    void Revive()
    {
        died = false;
    }



}
