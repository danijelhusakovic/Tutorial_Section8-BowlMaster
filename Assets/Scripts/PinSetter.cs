using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;
	public int lastStandingCount = -1;
	public float distanceToRaise = 40f;

	private bool ballEnteredBox;
	private float lastChangeTime;
	private Ball ball;

	// Use this for initialization
	void Start () {
		ballEnteredBox = false;
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString();

		if(ballEnteredBox){
			CheckStandingCount ();
		}
	}

	public void RaisePins(){
		Debug.Log ("Raising pins");
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.RaiseIfStanding ();
		}
	}

	public void LowerPins(){
		Debug.Log ("Lowering pins");
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Lower ();
		}
	}

	public void RenewPins(){
		Debug.Log ("Renewing pins");
	}


	void CheckStandingCount(){
		int currentStanding = CountStanding ();

		if(currentStanding != lastStandingCount){
			lastChangeTime = Time.time;
			lastStandingCount = currentStanding;
			return;
		}

		float settleTime = 3f;  // The amount of seconds pins have to settle. After this, we decide is it standing or not.
		if((Time.time - lastChangeTime > settleTime)){
			PinsHaveSettled ();
		}

	}

	void PinsHaveSettled(){
		ball.Reset ();
		lastStandingCount = -1; // Indicates pins have settled, and ball not back in box (?)
		ballEnteredBox = false;
		standingDisplay.color = Color.green;
	}


	int CountStanding(){
		int standing = 0;

		foreach(Pin pin in GameObject.FindObjectsOfType<Pin>()){
			if(pin.IsStanding()){
				standing++;
			}
		}

		return standing;

	}

	void OnTriggerEnter(Collider collider){
		if(collider.GetComponent<Ball>()){
			standingDisplay.color = Color.red;
			ballEnteredBox = true;
		}
	}

	void OnTriggerExit(Collider collider){
		if(collider.gameObject.GetComponent<Pin>()){
			Destroy (collider.gameObject);
		}
	}
}
