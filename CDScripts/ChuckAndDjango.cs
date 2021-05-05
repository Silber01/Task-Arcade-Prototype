using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChuckAndDjango : MonoBehaviour
{
    [SerializeField] float jumpSpeed = 40f;
    Rigidbody2D rigidbody2d;
    [SerializeField] Sprite jumping;
    [SerializeField] Sprite ducking;
    [SerializeField] Sprite running;
    [SerializeField] Animator animator;
    Vector2 jumpingOrDuckingSize = new Vector2(13.6f, 10.0f);
    Vector2 runningSize = new Vector2(13.6f, 12.4f);
    private enum States
    {
        RUNNING, JUMPING, DUCKING
    }
    States currentState;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Duck();
        if (transform.position.y < -2.98f)
        {
            Jump();
        }
        RunOrJumpSprite();
        Debug.Log(GetComponent<BoxCollider2D>().size);
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            rigidbody2d.velocity = new Vector3(0, jumpSpeed, 0);
        }
    }
    private void Duck()
    {
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("Test");
            if (currentState != States.DUCKING)
            {
                currentState = States.DUCKING;
                animator.SetInteger("StateSelect", 2); //ducking
                rigidbody2d.gravityScale = 20;
                GetComponent<BoxCollider2D>().size = jumpingOrDuckingSize;
            }
        }
        else
        {
            if (transform.position.y > -2.9f)
            {
                if (currentState != States.JUMPING)
                {
                    currentState = States.JUMPING;
                    animator.SetInteger("StateSelect", 1); //jumping
                    GetComponent<BoxCollider2D>().size = jumpingOrDuckingSize;
                }
            }
            else
            {
                if (currentState != States.RUNNING)
                {
                    currentState = States.RUNNING;
                    animator.SetInteger("StateSelect", 0); //running
                    GetComponent<BoxCollider2D>().size = runningSize;
                }
            }
            rigidbody2d.gravityScale = 5;
        }
    }
    private void RunOrJumpSprite()
    {
        
    }
}
