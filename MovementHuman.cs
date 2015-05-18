using UnityEngine;
using System.Collections;
public enum StateCharacterHuman
{
    Idle = 0,
    Walking = 1,
    Running = 2,
    Jumping = 3,
    Dancing = 4,
    Gungnum = 5,
    Throwing = 6,
}

public class MovementHuman : MonoBehaviour {

    private Animator animator;
    private float time;
    private float leapWalk;
    private bool checkRun;

    public StateCharacterHuman stateCharacterHuman;

    public bool isControllable = true;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        time = 0.0f;
        leapWalk = 0.0f;
        checkRun = false;
    }

    void UpdateSmoothedMovementDirection()
    {

        if (stateCharacterHuman != StateCharacterHuman.Dancing)
        {
            stateCharacterHuman = StateCharacterHuman.Idle;
            checkRun = false;
            
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            stateCharacterHuman = StateCharacterHuman.Walking;
            time = 0;
            checkRun = true;
           // print("input");

           
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (checkRun == true)
            {
                stateCharacterHuman = StateCharacterHuman.Running;
            }
            
            //animator.SetFloat("Speed", 1);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            stateCharacterHuman = StateCharacterHuman.Throwing;
        }

        if (stateCharacterHuman == StateCharacterHuman.Idle && time <= 15)
        {
            time += Time.deltaTime;
           // print("Time : " + time);
           // print("time <= 5");

            switch ((int)time)
            {
                case 15: stateCharacterHuman = StateCharacterHuman.Dancing;
                    break;
            }
        }

    }

    void FixedUpdate()
    {

        if (isControllable)
        {
            UpdateSmoothedMovementDirection();
        }

        if (animator)
        {
            if (stateCharacterHuman == StateCharacterHuman.Walking)
            {
                animator.SetBool("walk", true);

            }
            else if (stateCharacterHuman == StateCharacterHuman.Idle)
            {
                animator.SetBool("walk", false);
            }

            else if (stateCharacterHuman == StateCharacterHuman.Dancing)
            {
                //animator.SetBool("walk", false);
                animator.SetTrigger("dance");
            }
            // Check Running
            if (stateCharacterHuman == StateCharacterHuman.Running)
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

            if (stateCharacterHuman == StateCharacterHuman.Throwing)
            {
                animator.SetTrigger("Throw");
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

            switch((int)time)
            {
                case 5: animator.SetTrigger("dance");
                    //time = 0;
                    break;
            }   
        }
	
	}
*/

}
