using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;



	private PinCounter pinCounter;
	private Animator animator;

	ActionMasterOld actionMaster = new ActionMasterOld(); // we need it here as we want only one instance
															//(not creating always new in PinsHaveSettled ())

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		pinCounter = GameObject.FindObjectOfType<PinCounter> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void RaisePins(){
		foreach (Pin pin in GameObject.FindObjectsOfType<Pin>()){
			pin.RaiseIfStanding ();
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

	public void PerformAction(ActionMasterOld.Action action){
		if(action == ActionMasterOld.Action.Tidy){
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMasterOld.Action.EndTurn){
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset ();
		} else if (action == ActionMasterOld.Action.Reset){
			animator.SetTrigger ("resetTrigger");
			pinCounter.Reset ();
		} else if (action == ActionMasterOld.Action.EndGame){
			throw new UnityException ("Don't know how to handle end game yet.");
		}
	}




}
