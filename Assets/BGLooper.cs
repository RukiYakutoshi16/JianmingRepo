using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGLooper : MonoBehaviour {

    int numBGPanels = 3;

    void OnTriggerEnter2D(Collider2D collision) {
        //when BGLooper hits the background panel, get its height
        //float heightOfBGObject = collision.transform.localScale.y;

        //corrected for y scale of BGPanel being 42 instead of 40
        float heightOfBGObject = 40f; 


        Vector3 pos = collision.transform.position;

        //going to move that panel to the top of all the other panels 
        pos.y += (heightOfBGObject * numBGPanels);
        collision.transform.position = pos;

        //should have just moved the lowest panel, camera should not travel any lower than the middle of the panel the player is currently in (?)
        GetComponentInParent<CameraTracksPlayer>().minCameraHeight += 40;
    }
}
