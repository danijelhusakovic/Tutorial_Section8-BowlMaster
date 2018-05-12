﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Ball))]
public class DragLaunch : MonoBehaviour {

	private Ball ball;
	private Vector3 dragStart, dragEnd;
	private float starTime, endTime;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball> ();
	}

	public void DragStart (){
		dragStart = Input.mousePosition;
		starTime = Time.time;
	}

	public void DragEnd (){
		// v = s / t
		endTime = Time.time;
		dragEnd = Input.mousePosition;
		Vector3 s = dragEnd - dragStart;
		float t = endTime - starTime;
		Vector3 v = new Vector3 (s.x / t, 0f, s.y / t); // y is in the z. because we drag up, but the ball moves 'in'. 
														// else, the ball would move up to the sky. (and it did while programming)
		ball.Launch (v);
	}

}
