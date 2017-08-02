using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracksPlayer : MonoBehaviour {

    GameObject player;

    //min height at which the camera should not transform below
    public float minCameraHeight; 

	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate () {
        //if player travels 5 above the current y of the camera, move camera up 
        if (player.transform.position.y > transform.position.y + 5) {
            transform.position = new Vector3(0, player.transform.position.y - 5, -10);
        }

        //if player travels 5 below the current y of the camera and the height of the camera is greater than minCameraHeight, move the camera down
        if (player.transform.position.y < transform.position.y - 5 && transform.position.y > minCameraHeight) {
            transform.position = new Vector3(0, player.transform.position.y + 5, -10);
        }
        
        //if for some reason the y transform of the camera is less than minCameraHeight, set it equal to minCameraHeight
        if(transform.position.y < minCameraHeight) {
            transform.position = new Vector3(0, minCameraHeight, -10);
        }
	}

}
