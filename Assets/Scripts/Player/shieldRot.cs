using System.Collections;
using System.Collections.Generic;
//using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class shieldRot : MonoBehaviour
{
    //store player input
    private PlayerInput  pInput;
        
    // speed of rotation
    public float rotationSpeed = 5.0f;
    public Transform Player2;

    void Start()
    {
        //get player input
        pInput = GameObject.Find("Player2Body").GetComponentInParent<PlayerInput>();
    }

   


    void Update()
    {
        //makes sure that the shield is on the player 
        transform.position = Player2.position;
        //get player aim dir
        Vector2 aimDirection = pInput.actions.FindAction("AimInput").ReadValue<Vector2>();
        
        // Convert the Vector2 to an angle and add 90 degrees to correct the rotation
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;

        //check if player are moving the joystick
        if (aimDirection.x != 0 || aimDirection.y != 0)
        {
            // Create a target rotation based on the angle
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
