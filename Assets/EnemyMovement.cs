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
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (!inRange) {
			Face();
			Move();
		}
		else if (!attacking){
			Attack();
		}
	}
	
	void Face () {
		float atan = Mathf.Atan2((target.position.y - transform.position.y), (target.position.x - transform.position.x)) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0.0F, 0.0F, atan - 90);
	}
	
	void Move () {
		if (!RangeCheck()) {
			transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
		}
	}
	
	void Attack() {
		attacking = true;
		transform.GetChild(1).GetComponent<EnemySwing>().state = EnemySwing.State.windUp;
	}
	
	public bool RangeCheck() {
		distance = Vector3.Distance(transform.position, target.position);
		return inRange = distance < minDistance;
	}
}
