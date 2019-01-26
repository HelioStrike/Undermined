using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LeftButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler {

	public int value = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerUp(PointerEventData eventData) {
		value = 0;
	}

	public void OnPointerDown(PointerEventData eventData) {
		value = 1;
	}
}
