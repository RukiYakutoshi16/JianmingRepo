using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator Destruction() {
        //waits for 2 seconds...
        yield return new WaitForSeconds(2);
        //disable SpriteRenderer and EdgeCollider2D
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<EdgeCollider2D>().enabled = false; 

    }

    public void DestroySelf() {
        //when brick is hit by an enemy, it will 1) play a crumble animation 2) hide its sprite renderer and collider

        //is a coroutine for now:
        StartCoroutine("Destruction");
    }
}
