using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;
	public GameObject pinSet;

	private bool ballOutOfPlay;
	private int lastStandingCount = -1;
	private float lastChangeTime;
	private int lastSettledCount = 10;

	private Ball ball;
	private Animator animator;
	private ActionMaster actionMaster = new ActionMaster(); // we need it here as we want only one instance
															//(not creating always new in PinsHaveSettled ())

	// Use this for initialization
	void Start () {
		ballOutOfPlay = false;
		ball = GameObject.FindObjectOfType<Ball> ();
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString();

		if(ballOutOfPlay){
			standingDisplay.color = Color.red;
			UpdateStandingCountAndSettle ();
		}
	}

	public void SetBallOutOfPlay(){
		ballOutOfPlay = true;
	}

	public void RaisePins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.RaiseIfStanding ();
			pin.transform.rotation = Quaternion.Euler (270f, 0f, 0f);
		}
	}

	public void LowerPins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.Lower ();
		}
	}

	public void RenewPins(){
		GameObject newPins = Instantiate (pinSet);
		newPins.transform.position += new Vector3(0f, 50f, 0f);
	}


	void UpdateStandingCountAndSettle(){
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

		int standing = CountStanding ();
		int pinFall = lastSettledCount - standing;
		lastSettledCount = standing;

		ActionMaster.Action action = actionMaster.Bowl (pinFall);
		Debug.Log ("Pinfall: " + pinFall + " " + action);

		if(action == ActionMaster.Action.Tidy){
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn){
			animator.SetTrigger ("resetTrigger");
			lastSettledCount = 10;
		} else if (action == ActionMaster.Action.Reset){
			animator.SetTrigger ("resetTrigger");
			lastSettledCount = 10;
		} else if (action == ActionMaster.Action.EndGame){
			throw new UnityException ("Don't know how to handle end game yet.");
		}

		ball.Reset ();
		lastStandingCount = -1; // Indicates pins have settled, and ball not back in box (?)
		ballOutOfPlay = false;
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

}
