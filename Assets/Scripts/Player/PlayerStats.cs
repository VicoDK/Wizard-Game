using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour
{
    [Header("Player Stats")]

    public int playerNumber;
    

    [Header("Health")]
    public float Health; 
    public bool Alive = true; 
    
    private float MaxHealth;
    public float HealthRegn; 
    public float HealthRegnDelay;
    private bool AllowHeal = true;

    private float healTime;

    [Header("UI")]
    public GameObject DeathMenu;

    [Header("Weapon")]

    public float AmmoCap;


    [Header("Health bar")]
    public Image HealthBar;

    private SpriteRenderer Sprite;
    private PlayerInput  pInput;

 

    void Start()
    {
        
        MaxHealth = Health;

        Sprite = GetComponent<SpriteRenderer>();
        //pInput = GameObject.Find("PlayerBody").GetComponent<PlayerInput>();
        
    }   

    void Update()
    {

        if (playerNumber != 2)
        {
            //makes xTime count down 
            healTime -= Time.deltaTime;  
            //HealthBar.fillAmount = Health / MaxHealth;
        }


    }

    void FixedUpdate()
    {
        if (playerNumber != 2)
        {
            //runs when the time for regen to started runned out
            if (healTime < 0f)
            {
                //starts the players healing
                AllowHeal = true;

            }

            //this is for health regn
            if (Health < 0 || Health == 0)
            {
                Alive = false;
            }
            else if (MaxHealth > Health && AllowHeal)
            {
                Health += HealthRegn/50;
            }

            //this is to update health and mana bar
            HealthBar.fillAmount = Health / MaxHealth;
            //ManaBar.fillAmount = Mana / MaxMana;

            if (!Alive)
            {

                DeathMenu.SetActive(true);
                Time.timeScale = 0;
                Destroy(gameObject);
            }


            //for updating layout with coins 
            //CoinAmountDisplay.text = (Coin + " ");

        }

        
    }

    //function for taking damage
    public void TakeDamage(float Damage)
    {

        if (playerNumber == 1)
        {
            Health -= Damage;

            //stops the player from healing
            AllowHeal = false;

            //set the timer to HealthRegnDelay
            healTime = HealthRegnDelay;
        }


        

    } 

}
