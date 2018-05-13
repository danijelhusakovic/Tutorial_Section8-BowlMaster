using System.Collections;
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
		if( ! ball.launched){
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

	public void MoveStart(float amount){
		if( ! ball.launched){
			print ("Ball moved " + amount);
			ball.transform.position += new Vector3 (amount, 0f, 0f);
			if(ball.transform.position.x < -30){
				ball.transform.position = new Vector3 (-30f ,ball.transform.position.y, ball.transform.position.z);
			}
			if (ball.transform.position.x > 30) {
				ball.transform.position = new Vector3 (30f, ball.transform.position.y, ball.transform.position.z);
			}
		}

	}

}
