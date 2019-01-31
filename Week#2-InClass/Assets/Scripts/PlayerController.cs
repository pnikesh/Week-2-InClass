using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public variables
    public float speed = 10.0f;
    public float jumpForce = 1000;


    //Private veriables
    private Rigidbody2D rBody;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    //reserved function. Runs only once when the object is created
    void Start()
    {
       rBody = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))     //listen to spacebar key
        {
            rBody.AddForce(new Vector2(0 , jumpForce));
        }
    }
    //Ray cast from your feet doenwords twards the ground
    


    /// <summary>
   /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
   ///Use fixed update for physics based movements only 
   ///</summary>
   void FixedUpdate()
   {
       float horiz = Input.GetAxis("Horizontal");
      // float vert = Input.GetAxis("Vertical");

       //GetComponent<Rigidbody2D>().velocity = new Vector2(horiz,vert);
       rBody.velocity = new Vector2(horiz * speed, rBody.velocity.y);
   }
}
