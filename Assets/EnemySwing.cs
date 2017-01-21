using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwing : MonoBehaviour {

	// Inspector Variables
	public float windUpAngle;
	public float followThrough;
	public float windUpSpeed;
	public float swingSpeed;
	
	public enum State {windUp, swinging, reset, atEase};
	public State state;
	
	EnemyMovement parent;
	
	Vector3 startPosition;
	Quaternion startRotation;
	
		
	// Use this for initialization
	void Start () {
		state = State.atEase;
		startPosition = transform.localPosition;
		startRotation = transform.localRotation;
		parent = transform.parent.GetComponent<EnemyMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if (state != State.atEase) {
			Swing();
		}
	}

	
	void Swing() {
		if (state == State.windUp) {
			Vector3 pivot = transform.GetChild(0).position;
			transform.RotateAround(pivot, Vector3.forward, -(windUpSpeed * Time.deltaTime * 10));
			if (transform.localEulerAngles.z <= (135 - windUpAngle)) {
				state = State.swinging;
			}
		}
		else if (state == State.swinging) {
			Vector3 pivot = transform.parent.position;
			transform.RotateAround(pivot, Vector3.forward, swingSpeed * Time.deltaTime * 10);
			if (transform.localEulerAngles.z >= (135 + followThrough)) {
				state = State.reset;
			}
		}
		else if (state == State.reset) {
			state = State.atEase;
			Reset();
		}
	}
	
	
	void Reset() {
		GameObject newSword = Instantiate(this.gameObject, (this.gameObject.transform.parent.position + startPosition), startRotation, this.transform.parent);
		Destroy(gameObject);
		newSword.transform.localPosition = startPosition;
		newSword.transform.localRotation = startRotation;
		newSword.name = this.gameObject.name;
		parent.attacking = false;
		parent.RangeCheck();
	}
}
