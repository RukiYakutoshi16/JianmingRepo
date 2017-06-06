using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float xSpeed;
    public float ySpeed;

    float JUMP_TIME = 0.1f;
    float jumpTime;

    public bool jump = false;
    public bool walk = false; 

    public bool grounded; 

    void Start () {
        GetComponent<Rigidbody2D>().freezeRotation = true; 
	}

    void Update() {
        if (Input.GetButton("Horizontal")) {
            walk = true;
        } 
        else {
            walk = false;
        }

        if (Input.GetButton("Jump")) {
            jump = true; 
        }  
        else {
            jump = false;
        }
    }

    void FixedUpdate () {
        //if walking, add xSpeed force in the inputted direction 
        if (walk) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * xSpeed * Input.GetAxisRaw("Horizontal"));
        }

        if (jump) {
            //if player is touching a ground object, apply an instant velocity of ySpeed in the y direction (RigidBody2D's gravity will decrease it)
            //keep the velocity in the x at what it was (RigidBody2D's linear drag will slow it down)
            if (grounded) {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, ySpeed);
            }

            //when jump buttom is still held down, add 3 to the player's y velocity every frame for jumpTime seconds:
            //if player is still rising (positive velocity in y direction) and jumpTime is still greater than 0
            if (GetComponent<Rigidbody2D>().velocity.y > 0 && jumpTime > 0) {
                //add 3 to the player's current y velocity
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y + 3f);
                //decrement jumpTime
                jumpTime -= Time.deltaTime; 
            }
        }

        //when player hits the ground, reset jumpTime
        if (grounded) {
            jumpTime = JUMP_TIME;
        }

        //y velocity does not exceed 8 (in either direction)
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Clamp(GetComponent<Rigidbody2D>().velocity.x, -8, 8), GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnCollisionStay2D(Collision2D collision) {
        grounded = true;
    }

    void OnCollisionExit2D(Collision2D collision) {
        grounded = false;
    }

    public bool IsGrounded() {
        return true; 
    }

}
