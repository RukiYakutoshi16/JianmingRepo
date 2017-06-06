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

}
