using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 2f;
    Rigidbody2D myRigidBody2D;


    // Start is called before the first frame update
    void Start()
    {
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myRigidBody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {

        Movement();
    }

    private void  Movement()
    {
        if(IsFacingRight())
        {
            myRigidBody2D.velocity = new Vector2(movementSpeed, 0f);
        }
        else
        {
            myRigidBody2D.velocity = new Vector2(-movementSpeed, 0f);
        }
        
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2
        (Mathf.Abs(transform.localScale.x) *-(Mathf.Sign(myRigidBody2D.velocity.x)),transform.localScale.y);
    }
}
