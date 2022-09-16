using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    Animator animator;
    public bool jump = false;
    public bool run = false;
    public bool sit = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckRun();
        Animation();
    }

    void CheckRun()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            jump = true;
        if (Input.GetKey(KeyCode.LeftShift))
            run = true;
        else
            run = false;
        if (Input.GetKeyDown(KeyCode.LeftControl))
            sit = !sit;
    }

    void Play(string animation)
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName(animation))
        {
            animator.PlayInFixedTime(animation);
        }
    }

    public void EndJump()
    {
        jump = false;
        print("Закончили");
    }

    void Animation()
    {
        if (sit)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Play("Sneaking animation");
            }

            else if (Input.GetKey(KeyCode.A))
            {
                Play("Sneaking left animation");
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Play("Sneaking right animation");
            }
            else
            {
                Play("Sneak pose");
            }
        }
        else
        {
            if (playerMovement.isGrounded)
            {
                print("on the ground");
                if (jump)
                {
                    if (Input.GetKey(KeyCode.W) && run)
                    {
                        print(1);
                        Play("Run and jump");
                    }
                    else if (Input.GetKey(KeyCode.W))
                    {
                        Play("Walking jump");
                    }
                    else //if (Input.GetKeyDown(KeyCode.Space))//
                    {
                        Play("Jump");
                    }
                }
                else
                {
                    if (Input.GetKey(KeyCode.W) && run)
                    {
                        
                        Play("Running Animation");
                    }
                    else if (Input.GetKey(KeyCode.W))
                    {
                        Play("Walking Animation");
                    }
                    else if (Input.GetKey(KeyCode.S))
                    {
                        Play("Walking forward");
                    }
                    else if (Input.GetKey(KeyCode.A))
                    {
                        Play("Left walking animation");
                    }
                    else if (Input.GetKey(KeyCode.D))
                    {
                        Play("Right walking animation");
                    }
                    else
                    {
                        Play("Idle Animation");
                    }
                }
                    
            }
        }

    }
}