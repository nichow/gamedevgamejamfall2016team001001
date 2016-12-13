﻿using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	[Header("physics")]
	//grounded should be set to true during onCollisionStay() with the floor or a platform
	bool grounded = true;
	float timeHere;
	bool tooLong;
	Rigidbody2D rb;

	//stores the current speed
	float speed;

	//the maximum speed
	public float maxSpeed;

	//the rate of speed gain
	public float multiplier;

	//the rate at which the speed returns to 0 when turning around
	public float turnaroundSlowConstant;

	//the speed at which, if no button is held, it snaps to 0
	public float neutralSlowBounds;

	//the rate at which the speed slows with no button held
	public float neutralSlowConstant;

	//the initial jump force
	public float jumpForce;

	//the gradual jump force
	public float jumpForceGradual;

	// Use this for initialization
	void Start () {
		speed = 0;
		rb = GetComponent<Rigidbody2D> ();
		rb.gravityScale = 5;
		maxSpeed = 8;
		multiplier = 70;
		turnaroundSlowConstant = .55f;
		neutralSlowBounds = 1;
		neutralSlowConstant = .65f;
		jumpForce = 600;
		jumpForceGradual = 20;
		timeHere = Time.time;
		tooLong = true;
	}
	
	// Update is called once per frame
	void Update () {

		Horizontal ();
		Jump ();


	}

	//horizontal movement
	void Horizontal (){

		if (Input.GetButton ("Horizontal")) {
			var direction = Input.GetAxis ("Horizontal");

			if (direction < 0) {
				//left movement

				if (speed > 0) {
					//if it's moving in the opposite direction
					speed = speed * turnaroundSlowConstant;
				}
				speed = speed - Time.deltaTime * multiplier;
			}
			if (direction > 0) {
				//right movement

				if (speed < 0) {
					//if it's moving in the opposite direction
					speed = speed * turnaroundSlowConstant;
				}
				speed = speed + Time.deltaTime * multiplier;
			}
		} 
		if (!Input.GetButton ("Horizontal")) {
			if ((speed > neutralSlowBounds) || (speed < (-1 * neutralSlowBounds))) {
				speed = speed * neutralSlowConstant;
			} else {
				speed = 0;
			}
		}
		if (speed > maxSpeed) {
			speed = maxSpeed;
		} else if (speed < (-1 * maxSpeed)) {
			speed = -1 * maxSpeed;
		}

		//walk
		rb.velocity = new Vector2 (speed, rb.velocity.y);
	}

	//jumping
	void Jump(){
		//jumping
		//tooLong is used to determine the amount of time for which force should be gradually added
		tooLong = (Time.time - timeHere) > .3;

		//the grounded case
		if (Input.GetButtonDown ("Jump")) {
			if (grounded) {
				timeHere = Time.time;
				rb.AddForce (transform.up * jumpForce);
			}
		}

		//if jumping and the button is still held down and tooLong hasn't turned true yet
		if (Input.GetButton ("Jump") && !tooLong) {
			rb.AddForce (transform.up * jumpForceGradual);
		}
	}
		
}
