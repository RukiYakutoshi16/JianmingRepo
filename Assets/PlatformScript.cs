using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {

    public GameObject[] bricks;

	// Use this for initialization
	void Start () {
        GetAllChildren();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other) {
        //turn ignore on
        IgnoreBrickCollision(other, true);
    }

    void OnTriggerExit2D(Collider2D other) {
        //turn ignore off
        IgnoreBrickCollision(other, false);
    }

    void GetAllChildren() {
        int i = 0; 
        foreach(Transform child in gameObject.transform) {
            bricks[i] = child.gameObject;
            ++i;
        }
    }

    void IgnoreBrickCollision(Collider2D player, bool ignore) {
        foreach(GameObject brick in bricks) {
            Physics2D.IgnoreCollision(brick.GetComponent<BoxCollider2D>(), player.gameObject.GetComponent<EdgeCollider2D>(), ignore);
        }
    }
}
