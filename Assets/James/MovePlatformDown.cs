using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This handle the moving down platform
/// </summary>
public class MovePlatformDown : MonoBehaviour {
    /// <summary>
    /// find out the destination in Y position
    /// </summary>
    float finalYPosition;

    float top;
    

    public float range = -50f;

    public float speed = -2f;

    public float jumpTime = 3;

	// Use this for initialization
	void Start () {
        finalYPosition = transform.position.y;
        UpdateTop();
    }
	
	// Update is called once per frame
	void Update () {
    
        if (Input.GetButton("Jump"))
        {
            print("Move down");
            finalYPosition = transform.position.y + range; 

        }
        if(finalYPosition != transform.position.y)
        {
            float positionY = transform.position.y + speed * Time.deltaTime;
            Vector3 pos = new Vector3(transform.position.x, positionY, transform.position.z);
         
            transform.position = pos;
          
            if (finalYPosition > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, finalYPosition, transform.position.z);
                UpdateTop();
            }
        }
        if (top <= -15)
        {
            deleteBG();
        }
	}

    void UpdateTop()
    {
        top = transform.position.y + 15;
    
    }


    void deleteBG()
    {
        SpawnBG();
        GameObject.Destroy(this.gameObject);
    }

    void SpawnBG()
    {
        UpdateTop();
        Vector3 pos = new Vector3(0, top+60+15, 0);
        Instantiate(this.gameObject, pos, Quaternion.identity);
    }
}
