using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    //should be an array of different enemy types (?)
    public GameObject enemyPrefab; 

    //keep track of the current position of the player
    Transform player;

    //a timer, every x seconds should spawn another enemy
    float timer;
    public float enemyRespawnTime; 

	void Start () {
        timer = enemyRespawnTime; 
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	void Update () {
		if(timer >= 0) {
            timer -= Time.deltaTime;
        }
        else {
            //spawn an enemy
            //instantiated at x coordinate (for 21 by 40 panel): random int between -10 and 10, and y coordinate: player y + 40
            //modified for 24 by 40 BGPanel: random int [-12, 12) + 0.5, and y coordinate: player + 40
            Instantiate(enemyPrefab, new Vector3(Random.Range(-12, 12) + 0.5f, player.position.y + 40, -1), Quaternion.identity); 

            //reset the timer
            timer = enemyRespawnTime;
        }
	}

}
