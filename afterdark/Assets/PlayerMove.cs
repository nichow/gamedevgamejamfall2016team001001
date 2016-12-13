using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	[Header("physics")]
	//grounded should be set to true during onCollisionStay() with the floor or a platform
	bool grounded = true;
	float timeHere;
	bool tooLong;
	public Rigidbody2D rb;

	//stores the current speed
	float speed = 0;

	//the maximum speed
	public float maxSpeed = 20;

	//the rate of speed gain
	public float multiplier = 100;

	//the rate at which the speed returns to 0 when turning around
	public float turnaroundSlowConstant = .55f;

	//the speed at which, if no button is held, it snaps to 0
	public float neutralSlowBounds = 1;

	//the rate at which the speed slows with no button held
	public float neutralSlowConstant = .65f;

	//the initial jump force
	public float jumpForce = 750;

	//the gradual jump force
	public float jumpForceGradual = 48;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.gravityScale = 7;
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
