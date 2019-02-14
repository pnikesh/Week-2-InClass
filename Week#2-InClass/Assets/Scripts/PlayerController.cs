using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // PUBLIC VARIABLES
    public float speed = 10.0f;
    public float jumpForce = 100.0f;

    // PRIVATE VARIABLES
    private Rigidbody2D rBody;
    private Animator anim ;
    private bool isFacingRight = true;
    private bool isGrounded = false;
    //private bool canJump = false;

    // Reserved function. Runs only once when the object is created.
    // Used for initialization
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

     /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// Use FixedUpdate for Physics-based movement only
    /// </summary>
    void FixedUpdate()
    {
        float horiz = Input.GetAxis("Horizontal");

        // Listens to my space bar key being pressed
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rBody.AddForce(new Vector2(0, jumpForce));
            isGrounded = false;
            //canJump = false;
        }

        rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);

        //check direction of player
        if(horiz < 0 && isFacingRight)
        {
            Flip();
        }
        else if(horiz > 0 && !isFacingRight)
        {
            Flip();
        }
        //Update animator information
        anim.SetFloat("Speed", Mathf.Abs(horiz));
    }

    void OnCollisionEnter2D(Collision2D other)
    {
      if(other.gameObject.CompareTag("Ground"))
      {
          isGrounded = true;
      }   
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector2 temp = transform.localScale;
        temp.x *= -1;
        transform.localScale = temp;

    }
}