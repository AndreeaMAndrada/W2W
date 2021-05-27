using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float PlayerSpeed;
    private float moveInput;
    public float jumpForce;
    private Animator anim;//animator declarinf
    private Rigidbody2D myRigidbody; //declares the rigid body

    public bool isGrounded ; //is the player on the ground
    public Transform feetPos; //feet position
    public float checkRadius;  //the radius neaby
    public LayerMask whatisGround; //what the ground should be

    private float jumpTimeCounter; //same as jump time
    public float jumpTIme; //for how long can they jump
    private bool isJumping;  //is the player jumping

    private int extraJumps; // same as value , how many extra jumps can be made
    public int extraJumpsValue;

    private bool playerMoving; // true or false based on Input
    private Vector2 lastMove;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue; 
        anim = GetComponent<Animator>();//declare the animator once as it only Starts
        myRigidbody = GetComponent<Rigidbody2D>(); //declare the rigid body
    }
    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        myRigidbody.velocity = new Vector2(moveInput * PlayerSpeed, myRigidbody.velocity.y);
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatisGround); // checks for the ground 
    }
    // Update is called once per frame
    void Update()
    {

        Animate();  //animator fucntion called
        Jump(); //jump function called
    }

    private void Animate()
    {
        playerMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5 || Input.GetAxisRaw("Horizontal") < -0.5)
        {
            //transform.Translate(new Vector3(Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime, 0f, 0f));
            //  myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * PlayerSpeed, myRigidbody.velocity.y);
            playerMoving = true; //set true due to the player moving
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f); //we get the Vector 2 with the exact coordonates at that time.

        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal")); //all parameters from animator are inputted in here
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("IsMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
    }


    private void Jump()
    {
        if (isGrounded == true)  // if is on ground resets the jump value
        {
            extraJumps = extraJumpsValue;
        }


        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)  // is the space key is pressed and there is a extra jump available
        {
            myRigidbody.velocity = Vector2.up * jumpForce; //make the jump
            isJumping = true;  // set the fact that the jump is true
            jumpTimeCounter = jumpTIme; // give the value to the time the jump can be made if this is removed the hold jump no more
            extraJumps--;  // -1 per each space bar hit

        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true) //else  if there is no more extra jumps just normal jump
        {
            myRigidbody.velocity = Vector2.up * jumpForce;
            isJumping = true;
            jumpTimeCounter = jumpTIme;
        }

        if (Input.GetKey(KeyCode.Space)) //if the spacebar is pressed
        {


            if (jumpTimeCounter > 0 && isJumping == true) // if the timer is there and is jumping
            {
                myRigidbody.velocity = Vector2.up * jumpForce; //make jump

                jumpTimeCounter -= Time.deltaTime; //minus the time it takes for the jump

            }
            else
            {
                isJumping = false;
            }

        }
        if (Input.GetKeyUp(KeyCode.Space)) // if the key is let down no more jumping
        {
            isJumping = false;
        }
    }
    

    
    
}
