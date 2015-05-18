using UnityEngine;
using System.Collections;

public enum StateCharacterGiant
{
    Idle = 0,
    Walking = 1,
    Running = 2,
    Jumping = 3,
    Dancing = 4,
    Gungnum = 5,
    Attack = 6,
}

public class MovementGiant : MonoBehaviour {

    private Animator animator;
    private float time;
    private bool checkRun;

    public StateCharacterGiant stateCharacterGiant;

    public bool isControllable = true;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        time = 0.0f;
        checkRun = false;
    }

    void UpdateSmoothedMovementDirection()
    {

        if (stateCharacterGiant != StateCharacterGiant.Dancing)
        {
            stateCharacterGiant = StateCharacterGiant.Idle;

        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            stateCharacterGiant = StateCharacterGiant.Walking;
            time = 0;
            // print("input");
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (checkRun == true)
            {
                stateCharacterGiant = StateCharacterGiant.Running;
            }

            //animator.SetFloat("Speed", 1);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            stateCharacterGiant = StateCharacterGiant.Attack;
        }

        if (stateCharacterGiant == StateCharacterGiant.Idle && time <= 5)
        {
            time += Time.deltaTime;
            // print("Time : " + time);
            // print("time <= 5");

            switch ((int)time)
            {
                case 5: stateCharacterGiant = StateCharacterGiant.Dancing;
                    break;
            }
        }

    }

    void FixedUpdate()
    {
        //print(animator.GetCurrentAnimatorStateInfo(0));

        if (isControllable)
        {
            UpdateSmoothedMovementDirection();
        }

        if (animator)
        {
            if (stateCharacterGiant == StateCharacterGiant.Walking)
            {
                animator.SetBool("walk", true);
            }
            else if (stateCharacterGiant == StateCharacterGiant.Idle)
            {
                animator.SetBool("walk", false);
            }
            else if (stateCharacterGiant == StateCharacterGiant.Dancing)
            {
                //animator.SetBool("walk", false);
                animator.SetTrigger("dance");
            }

            if (stateCharacterGiant == StateCharacterGiant.Running)
            {
                //leapWalk += 0.1f;
                animator.SetBool("walk", true);
                animator.SetFloat("Speed", 1);
            }
            else
            {
                //leapWalk -= 0.1f;
                animator.SetFloat("Speed", -1);
            }
        }
    }

    /*
    void FixedUpdate()
    {
        //print("Time For Dance : " + time);

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("walk", true);
            time = 0;
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("walk", false);
        }
        else if (animator.GetBool("walk") == false && time <= 5)
        {
            time += Time.deltaTime;

            switch ((int)time)
            {
                case 5: animator.SetTrigger("dance");
                    //time = 0;
                    break;
            }
        }

    }
     */
}
