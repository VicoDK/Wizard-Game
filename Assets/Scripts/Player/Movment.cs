using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Movment : MonoBehaviour
{

    [Header("Player Controlls")]
    //this is the input maneger

    //public InputAction PlayerMovment;
    private PlayerInput  pInput;
    Vector2 MoveDir = Vector2.zero;

    //player speed
    public float speed;
    private float StartSpeed;
    public float DashSpeedv2;
    public float slowprocent;
    private float slow = 1f;

    //dash
    public float dashSpeed;
    bool canDash = true; 
    bool canMove = true; 
    float currentDashTime;
    float startDashTime = 0.3f;
    public bool dashing;

    //Sprit
    public float SpritSpeed;
    bool canSprit = true;
    public float SpritTime;
    public float SpritCooldown;
    public float SpritCastTime;

    //rigibody
    [SerializeField] private Rigidbody2D rb;
    
    //animation
    public Animator animator;

    
    PlayerStats PlayerStat;
    public bool DashType;

    private void Start()
    {
        animator = GetComponent<Animator>();
        StartSpeed = speed;
        PlayerStat = GetComponent<PlayerStats>();
        pInput = GetComponent<PlayerInput>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //read player input
        MoveDir = pInput.actions.FindAction("Move").ReadValue<Vector2>();
    
        if (PlayerStat.playerNumber == 2)
        {
            if (pInput.actions["Dash"].WasPressedThisFrame() && canDash)
            {
                StartCoroutine(Dash(MoveDir));
               
            }

        }

        if (PlayerStat.playerNumber == 1)
        {
            if (pInput.actions["Sprit"].WasPressedThisFrame() && canSprit)
            {
                StartCoroutine(Sprit());

            }

        }

        Flip();
        if (MoveDir.x != 0 || MoveDir.y != 0)
        {
            animator.SetBool("Speed", true);

        }
        else 
        {
            animator.SetBool("Speed", false);
        }
      

    }

    void FixedUpdate()
    {
        if (canMove) 
        {
            //gameObject.transform.Translate(MoveDir.x * speed , MoveDir.y * speed ,0 );
            rb.linearVelocity = new Vector3(MoveDir.x * speed , MoveDir.y * speed, 0).normalized * speed * slow;
        }
    }


    IEnumerator Dash(Vector2 direction)
    {
        if (DashType)
        {
            dashing = true;
            canDash = false; // When Player Dash, Player Cannot Move
            canMove = false; // And Player Cannot Dash

            currentDashTime = startDashTime; // Reset the dash timer.

            while (currentDashTime > 0f)
            {
                currentDashTime -= Time.deltaTime; // Lower the dash timer each frame.

                direction.Normalize();
                rb.linearVelocity = direction * dashSpeed; // Dash in the direction that was held down.
                                                           // No need to multiply by Time.DeltaTime here, physics are already consistent across different FPS.

                yield return null; // Returns out of the coroutine this frame so we don't hit an infinite loop.
            }

            rb.linearVelocity = new Vector2(0f, 0f); // Stop dashing.
            dashing = false;
        }
        else
        {
            dashing = true;
            speed = DashSpeedv2;

            yield return new WaitForSeconds(0.2f);

            speed = StartSpeed;
            dashing = false;




        }



    }
    IEnumerator Sprit()
    {

        canSprit = false;
        speed = 0f;
        yield return new WaitForSeconds(SpritCastTime);
        speed = SpritSpeed;
        yield return new WaitForSeconds(SpritTime);
        speed = StartSpeed;
        yield return new WaitForSeconds(SpritCooldown);
        canSprit = true;
    }

    void Flip()
    {

        if (MoveDir.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1,1,1);
        }
        else if (MoveDir.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1,1,1);
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Swamp"))
        {
            slow = slowprocent;

        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Swamp")) 
        {
            slow = 1f;
        
        }
    }









}
