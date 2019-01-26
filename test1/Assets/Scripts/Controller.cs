using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	public float jumpSpeed;
	private long lastJump = 0;
	private int jumpsLeft = 2;
	private bool canJump = true;
	public float jumpGap;
	public GameObject model;
	private Animator anim;
	private float horizontal, vertical;
	private bool currDir = true, newDir;
	private JoyButton leftButton;
	private JoyButton rightButton;
	private JoyButton jumpButton;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
		anim = model.GetComponent<Animator>();
		leftButton = GameObject.Find("LeftButton").GetComponent<JoyButton>();
		rightButton = GameObject.Find("RightButton").GetComponent<JoyButton>();
		jumpButton = GameObject.Find("JumpButton").GetComponent<JoyButton>();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate() {
		horizontal = rightButton.value - leftButton.value;
		vertical = jumpButton.value;

		newDir = (horizontal > 0);
		if(horizontal != 0 && newDir != currDir) {
        	transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
			currDir = newDir;
		}

		rb.velocity = new Vector3(horizontal*speed,rb.velocity.y,0);

		if(vertical != 0) {
			if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
			{
				anim.Play("Jump",0,0.1f);
			}
		}
		else if(horizontal != 0) {
			if(Math.Abs(rb.velocity.y) < 0.0001 && !anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
			{
				anim.Play("Walk",0,0.3f);
			}
		}

		if(vertical > 0 && canJump == true && jumpsLeft > 0) {
			jump();
			jumpsLeft -= 1;
			Invoke("resetCanJump", jumpGap);
		}
	}

	void jump() {
		rb.velocity = new Vector3(horizontal*speed,jumpSpeed,0);
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
