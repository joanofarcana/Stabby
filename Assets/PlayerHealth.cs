using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
	
	public int startingHealth = 3;                            // The amount of health the player starts the game with.
    public int currentHealth;                                   // The current health the player has.
    public Slider healthSlider;                                 // Reference to the UI's health bar.
    //public Image damageImage;                                   // Reference to an image to flash on the screen on being hurt.
    //public float flashSpeed = 5f;                               // The speed the damageImage will fade at.
    //public Color flashColour = new Color(1f, 0f, 0f, 0.1f);     // The colour the damageImage is set to, to flash.


    PlayerMovement playerMovement;                              // Reference to the player's movement.
    bool isDead;                                                // Whether the player is dead.
    bool damaged;                                               // True when the player gets damaged.
	
	
	// Use this for initialization
	void Start () {
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void TakeDamage(int amount) {
		damaged = true;
		
		currentHealth -= amount;
		
		healthSlider.value = currentHealth;
		
		if(currentHealth <= 0 && !isDead) {
			Death();
		}
	}
	
	void Death() {
		isDead = true;
		Debug.Log("You died.");		
	}
	
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "enemyweapon") {
			TakeDamage(1);
			Debug.Log("You are hit!");
		}
	}
}
