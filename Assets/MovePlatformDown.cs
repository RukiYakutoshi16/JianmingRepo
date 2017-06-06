using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//handles the moving-down platform
public class MovePlatformDown : MonoBehaviour {

    //find out the y-position destination 
    float finalYPosition;

    float top;

    public float range;
    public float speed;

    PlayerMovement player;

	void Start () {
        finalYPosition = transform.position.y;
        UpdateTop();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }

    void Update() {
        if (Input.GetButtonDown("Jump") && player.IsGrounded()) {
            finalYPosition = transform.position.y + range;
        }
    }

    void FixedUpdate() {
        UpdateTop();

        if (top <= 0) {
            deleteBG();
        }

        if (transform.position.y != finalYPosition) {
            float positionY = transform.position.y + speed * Time.deltaTime;
            Vector3 pos = new Vector3(transform.position.x, positionY, transform.position.z);
            transform.position = pos;

            if (transform.position.y < finalYPosition) {
                transform.position = new Vector3(transform.position.x, finalYPosition, transform.position.z);
            }
        }
    }

    void UpdateTop() {
        top = transform.position.y + 20;
    }

    void SpawnBG() {
        print(top);
        Vector3 pos = new Vector3(0, top + 40 + 20, 0);
        Instantiate(gameObject, pos, Quaternion.identity);
    }

    void deleteBG() {
        SpawnBG();
        Destroy(gameObject);
    }
}
