using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingEnemy : MonoBehaviour {

	void Start () {
        //so that the enemy cannot randomly rotate
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }
	
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision) {
        //if collsition with a brick object, destroy the brick
        if (collision.gameObject.tag == "Brick") {
            collision.gameObject.GetComponent<BrickScript>().DestroySelf();
        }
    }

}
