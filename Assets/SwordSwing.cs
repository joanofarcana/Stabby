using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour {

	// Inspector Variables
	public float windUpAngle;
	public float followThrough;
	public float windUpSpeed;
	public float swingSpeed;
	
	enum State {windUp, swinging, reset, atEase};
	State state;
	
	Vector3 startPosition;
	Quaternion startRotation;
	
		
	// Use this for initialization
	void Start () {
		// Debug.Log(transform.position);
		// Debug.Log(transform.localPosition);
		// Debug.Log(transform.localEulerAngles.z);
		state = State.atEase;
		startPosition = transform.localPosition;
		startRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0) || state != State.atEase) {
			if (state == State.atEase)
				state = State.windUp;
			Swing();
		}
	}

	
	void Swing() {
		//Debug.Log(state + ", " + transform.forward + ", " + transform.localPosition);
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
	}
}
