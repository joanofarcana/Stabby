using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public Transform target;
	public float speed = 2f;
	private float minDistance = 1.5f;
	private float distance;
	public bool inRange;
	public bool attacking;
	
	EnemySwing sword;
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!inRange) {
			Move();
		}
		else if (!attacking){
			Attack();
		}
	}
	
	void Move () {
		if (!RangeCheck()) {
			transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
	}
	
	void Attack() {
		attacking = true;
		sword = this.GetComponentInChildren<EnemySwing>();
		sword.state = EnemySwing.State.windUp;
	}
	
	public bool RangeCheck() {
		distance = Vector3.Distance(transform.position, target.position);
		return inRange = distance < minDistance;
	}
}
