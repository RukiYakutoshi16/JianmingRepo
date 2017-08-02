using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    public GameObject[] bricks;

	void Start () {
        GetAllChildren();
    }

    void OnTriggerEnter2D(Collider2D other) {
        //ignore collisions between player and bricks[]
        IgnoreBrickCollision(other, true);
    }

    void OnTriggerExit2D(Collider2D other) {
        //undo the ignore collisions between player and bricks[]
        IgnoreBrickCollision(other, false);
    }

    //a one-way platform is made of bricks, get all the brick GameObjects and stash them in the bricks[]
    void GetAllChildren() {
        int i = 0; 
        foreach(Transform child in gameObject.transform) {
            bricks[i] = child.gameObject;
            ++i;
        }
    }

    //collisions between player and everything in bricks[] will be set to argument ignore
    void IgnoreBrickCollision(Collider2D player, bool ignore) {
        foreach(GameObject brick in bricks) {
            if (brick.GetComponent<EdgeCollider2D>().enabled == true) {
                Physics2D.IgnoreCollision(brick.GetComponent<EdgeCollider2D>(), player.gameObject.GetComponent<BoxCollider2D>(), ignore);
            }
        }
    }
}
