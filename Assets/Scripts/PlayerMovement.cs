using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 4f;
    public float gravity = -6.81f;
    public float jumpHeight = 3f;
 
    
    

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Transform cylinder;

    Vector3 velocity;
    public bool isGrounded;
    bool sit = false;
    float timeJump;


    void Update()
    {
        if (timeJump>0)
        {timeJump -= Time.deltaTime;}
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Ctrl"))
        {
            sit = !sit;
            if (sit)
            {
                GetComponent<CharacterController>().height = 0.8f;
                speed = 1f;
            }
            else
            {
                GetComponent<CharacterController>().height = 1.8f;
                speed = 5f;
            }
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetButton("Shift"))
        {
            speed = 8f;
        }
        else
        {
            speed = 4f;
        }



        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
