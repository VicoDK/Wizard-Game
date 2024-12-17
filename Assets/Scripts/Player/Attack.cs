using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : MonoBehaviour
{
    [Header("Player Input System")]
    //add new input system
    private PlayerInput pInput;
    [Header("Fire Point")]
    public Transform FirePoint;


    [Header("Basic attack")]
    public float Speed;
    public GameObject BaseAttack;
    public bool AttackReady = true;

    [Header("Heavy attack")]
    public float Speed2;
    public GameObject Heavyattack;
    public bool AttackReady2 = true;

    [Header("Ammo")]
    private float AmmoCap;
    public float AmmoCount;
    public float ReloadSpeed = 2f;
    public float FireRate = 0.5f;

    PlayerStats PlayerStat;

    private void Start()
    {
        PlayerStat = GetComponent<PlayerStats>();
        pInput = GetComponent<PlayerInput>();
        AmmoCap = PlayerStat.AmmoCap;
        AmmoCount = 4f;
    }




    void Update()
    {
        //base attack
        //here we check after input and if attack is ready
        if (pInput.actions["Fire"].WasPressedThisFrame() && AttackReady)
        {

            //all the code made from line 19 to 45 is made by ChatGBT (with some small changes) with this promt "make a script for unity2d, where the players mouse is fire a object there"
            // Get mouse position
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Calculate direction towards mouse position
            Vector2 fireDir = (mousePosition - FirePoint.position).normalized;

            // Instantiate bullet at fire point
            GameObject bullet = Instantiate(BaseAttack, FirePoint.position, Quaternion.identity);

            // Rotate bullet towards mouse position
            float angle = Mathf.Atan2(fireDir.y, fireDir.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
            BasicAttack basicAttack = bullet.GetComponent<BasicAttack>();
            basicAttack.DataTranfor(fireDir, Speed);
            // Add force to the bullet
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(fireDir * Speed, ForceMode2D.Impulse);

            //here we start a IEnumerator for the timer
            StartCoroutine(AttackDelay());

        }
        if (pInput.actions["HeavyFire"].WasPressedThisFrame() && AttackReady)
        {
            AttackReady = false;
            Invoke("HeavyattackFire", 1);
        }

    }

    public void HeavyattackFire()
    {

        //all the code made from line 19 to 45 is made by ChatGBT (with some small changes) with this promt "make a script for unity2d, where the players mouse is fire a object there"
        // Get mouse position
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        // Calculate direction towards mouse position
        Vector2 fireDir = (mousePosition - FirePoint.position).normalized;

        // Instantiate bullet at fire point
        GameObject bullet = Instantiate(Heavyattack, FirePoint.position, Quaternion.identity);

        // Rotate bullet towards mouse position
        float angle = Mathf.Atan2(fireDir.y, fireDir.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        HeavyAttack heavyattack = bullet.GetComponent<HeavyAttack>();
        heavyattack.DataTranfor(fireDir, Speed);
        // Add force to the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(fireDir * Speed2, ForceMode2D.Impulse);

        //here we start a IEnumerator for the timer
        StartCoroutine(AttackDelay());

    }


    //this is the IEnumerator for timer
    public IEnumerator AttackDelay()
    {
        
       
        //attack is not ready to go now
        AttackReady = false;
        AmmoCount--;
        //here we wait some time
        yield return new WaitForSeconds(FireRate);
        //now attack is ready
        if (AmmoCount == 0)
        {
            yield return new WaitForSeconds(ReloadSpeed);
            AmmoCount = 4;

        }

        AttackReady = true;
    }
}