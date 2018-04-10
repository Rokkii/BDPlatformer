using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {

    public float movementSpeed;
    private float moveSpeedStore;
    public float jumpForce;

    public float speedMultiplier;
    public float speedIncreaseMilestone;
    private float speedIncreaseMilestoneStore;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;

    public float jumpTime;
    private float jumpTimeCounter;

    private Rigidbody2D objRigidBody;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    //private Collider2D myCollider;

    private Animator playerAnimator;

    public GameManager theGameManager;

    // Use this for initialization
    void Start () {

        objRigidBody = GetComponent<Rigidbody2D>(); /*Get RigidBody for object to allow interaction*/

        //myCollider = GetComponent<Collider2D>(); /*Finds box collider attached to player*/

        playerAnimator = GetComponent<Animator>(); /*Finds animator attached to player*/

        jumpTimeCounter = jumpTime;

        speedMilestoneCount = speedIncreaseMilestone;

        moveSpeedStore = movementSpeed;

        speedMilestoneCountStore = speedMilestoneCount;

        speedIncreaseMilestoneStore = speedIncreaseMilestone;

	}
	
	// Update is called once per frame
	void Update () {

        //grounded = Physics2D.IsTouchingLayers(myCollider, whatIsGround); /*Check if player & platform colliders are touching and set true/false if player is grounded*/

        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (transform.position.x > speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;

            movementSpeed = movementSpeed * speedMultiplier;
        }

        objRigidBody.velocity = new Vector2(movementSpeed, objRigidBody.velocity.y); /*Set movement velocity of object = movementSpeed*/

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) /*If Unity detects space bar or mouse button is pressed run loop*/
        {
            if (grounded) 
            { 
                objRigidBody.velocity = new Vector2(objRigidBody.velocity.x, jumpForce); /*Change y velocity to = jumpForce*/
            }
        }


        if (Input.GetKey (KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (jumpTimeCounter > 0)
            {
                objRigidBody.velocity = new Vector2(objRigidBody.velocity.x, jumpForce); /*Change y velocity to = jumpForce*/
                jumpTimeCounter -= Time.deltaTime;
            }
        }


        if (Input.GetKeyUp (KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
        }


        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }


        playerAnimator.SetFloat("Speed", objRigidBody.velocity.x); /*Get x value of rigid body and set this to speed*/

        playerAnimator.SetBool("Grounded", grounded); /*Get grounded value of player*/


    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "DeadFloor")
        {
            theGameManager.RestartGame();   // Calls Restart game loop from theGameManager within GameManager script
            movementSpeed = moveSpeedStore; // Reset movement speed
            speedMilestoneCount = speedMilestoneCountStore; // Reset milestone count
            speedIncreaseMilestone = speedIncreaseMilestoneStore;   // Reset speed increase milestone
        }
    }

}
