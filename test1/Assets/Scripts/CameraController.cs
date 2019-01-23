using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	GameObject player;
	Vector3 offset;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		offset = this.transform.position - player.transform.position;
	}
	
	void LateUpdate () {
		this.transform.position = offset + player.transform.position;
	}
}
