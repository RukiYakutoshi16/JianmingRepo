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
            //instantiated at x coordinate: random int between -10 and 10, and y coordinate: player y + 40
            Instantiate(enemyPrefab, new Vector3(Random.Range(-10, 10), player.position.y + 40, -1), Quaternion.identity); 

            //reset the timer
            timer = enemyRespawnTime;
        }
	}

}
