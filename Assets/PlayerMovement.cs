using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	
	//Inspector Variables
	public float playerSpeed = 1.5f; 	//speed player moves
 
	void Start() {
	}
 
	void Update() {
		Move(); 			// Player Movement
	}
 
 
	void Move() {
		if(Input.GetKey(KeyCode.W)) {		// up
			transform.position += Vector3.up * playerSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.S)) {		// down
			transform.position += -Vector3.up * playerSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.D)) {		// right
			transform.position += Vector3.right * playerSpeed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A)) {		// left
			transform.position += -Vector3.right * playerSpeed * Time.deltaTime;
		}
	}

	
}
