using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField] float runSpeed = 2f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] Vector2 dieAnimation = new Vector2(10f, 10f);

    Rigidbody2D myRigidBody;
    Animator MyAnimator;
    CapsuleCollider2D myBodyCollider2D;
    BoxCollider2D myFeetCollider2D;

    bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
        MyAnimator = GetComponent<Animator>();
        myBodyCollider2D = GetComponent<CapsuleCollider2D>();
        myFeetCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
        Jump();
        Dying();
    }

    private void Run()
    {
        var movement = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(movement * runSpeed, myRigidBody.velocity.y);
        myRigidBody.velocity = playerVelocity;

        
        bool playerHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHorizontalSpeed)
        {
            MyAnimator.SetBool("Running",true);
        }
        else
        {
            MyAnimator.SetBool("Running", false);
        }
    }

    private void Jump()
    {
        if (!myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }


        if(Input.GetButtonDown("Jump"))
        {
            Vector2 addJumpVelocity = new Vector2(0f, jumpSpeed);
            myRigidBody.velocity += addJumpVelocity;
        }
    }
    private void  FlipSprite()
    {
        
        bool playerHorizontalSpeed = Mathf.Abs(myRigidBody.velocity.x) > Mathf.Epsilon;
        if(playerHorizontalSpeed)
        {
            transform.localScale = new Vector2
            (Mathf.Abs(transform.localScale.x) * Mathf.Sign(myRigidBody.velocity.x),transform.localScale.y);
            
        }
    }

    private void Dying()
    {
        if(myBodyCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemy","Hazards")))
        {
            isAlive = false;
            MyAnimator.SetTrigger("Dying");
            GetComponent<Rigidbody2D>().velocity = dieAnimation;
            FindObjectOfType<GameSession>().PlayerDeath();

        }
    }
    
    
}
