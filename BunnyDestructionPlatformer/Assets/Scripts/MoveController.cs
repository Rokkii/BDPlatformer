﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    public float movementSpeed;
    public float jumpForce;

    private Rigidbody2D objRigidBody;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D myCollider;

    private Animator playerAnimator;

    // Use this for initialization
    void Start () {

        objRigidBody = GetComponent<Rigidbody2D>(); /*Get RigidBody for object to allow interaction*/

        myCollider = GetComponent<Collider2D>(); /*Finds box collider attached to player*/

        playerAnimator = GetComponent<Animator>(); /*Finds animator attached to player*/

	}
	
	// Update is called once per frame
	void Update () {

        grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround); /*Check if player & platform colliders are touching and set true/false if player is grounded*/



        objRigidBody.velocity = new Vector2(movementSpeed, objRigidBody.velocity.y); /*Set movement velocity of object = movementSpeed*/

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) /*If Unity detects space bar or mouse button is pressed run loop*/
        {
            if (grounded) 
            { 
                objRigidBody.velocity = new Vector2(objRigidBody.velocity.x, jumpForce); /*Change y velocity to = jumpForce*/
            }
        }

        playerAnimator.SetFloat("Speed", objRigidBody.velocity.x); /*Get x value of rigid body and set this to speed*/

        playerAnimator.SetBool("Grounded", grounded); /*Get grounded value of player*/


    }
}
