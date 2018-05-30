using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Ball))]
public class BallDragLaunch : MonoBehaviour {

	private Ball ball;
	private Vector3 dragStart, dragEnd;
	private float startTime, endTime;

	// Use this for initialization
	void Start () {
		ball = GetComponent<Ball> ();
	}

	public void DragStart (){
		if( ! ball.launched){
			dragStart = Input.mousePosition;
			startTime = Time.time;	
		}
	}

	public void DragEnd (){
		if( ! ball.launched){
			// v = s / t
			endTime = Time.time;
			dragEnd = Input.mousePosition;
			Vector3 s = dragEnd - dragStart;
			float t = endTime - startTime;
			Vector3 v = new Vector3 (s.x / t, 0f, s.y / t); // y is in the z. because we drag up, but the ball moves 'in'. 
			// else, the ball would move up to the sky. (and it did while programming)
			ball.Launch (v);
		}

	}

	public void MoveStart(float amount){
		if( ! ball.launched){
			float xPos = Mathf.Clamp (ball.transform.position.x + amount, -30f, 30f);
			float yPos = ball.transform.position.y;
			float zPos = ball.transform.position.z;

			ball.transform.position = new Vector3 (xPos, yPos, zPos);
		}

	}

}
