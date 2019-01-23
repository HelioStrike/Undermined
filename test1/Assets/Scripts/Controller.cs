using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public float jumpForce;
	private long lastJump = 0;
	private int jumpsLeft = 2;
	private bool canJump = true;
	public float jumpGap;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		rb.velocity = new Vector3(Input.GetAxis("Horizontal")*speed,rb.velocity.y,0);
		if(Input.GetAxis("Vertical") > 0 && canJump == true && jumpsLeft > 0) {
			jump();
			jumpsLeft -= 1;
			Invoke("resetCanJump", jumpGap);
		}
	}

	void jump() {
		rb.AddForce(new Vector3(0,jumpForce, 0));
		canJump = false;
	}

	void resetCanJump() {
		canJump = true;
	}

	void OnCollisionEnter(Collision collisionInfo)
	{
		jumpsLeft = 2;	
	}
}
