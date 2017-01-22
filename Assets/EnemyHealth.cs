using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	// Inspector Variables
	public int startingHealth = 2;
    public int currentHealth;
    public Slider healthSlider;
	
	bool damaged;
	bool isDead;

	// Use this for initialization
	void Start() {
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update() {
		
	}
	
	void FixedUpdate() {
		
	}
	
	void TakeDamage(int amount) {
		damaged = true;
		
		currentHealth -= amount;
		
		healthSlider.value = currentHealth;
		
		if(currentHealth <= 0 && !isDead) {
			Death();
		}
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "playerweapon") {
			TakeDamage(1);
			Debug.Log("Hit!");
		}
	}
	
	void Death() {
		Destroy(gameObject);
	}
	
}
