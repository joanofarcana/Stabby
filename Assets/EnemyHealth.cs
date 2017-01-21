using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	// Inspector Variables
	public float health = 100;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}
	
	void FixedUpdate() {
		
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "playerweapon") {
			HitBySword(col);
			Debug.Log("Hit!");
		}
	}
	
	void HitBySword(Collider2D col) {
		Destroy(gameObject);
	}
	
}
