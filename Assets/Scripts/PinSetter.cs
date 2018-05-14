using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text standingDisplay;

	private bool ballEnteredBox;

	// Use this for initialization
	void Start () {
		ballEnteredBox = false;
	}
	
	// Update is called once per frame
	void Update () {
		standingDisplay.text = CountStanding ().ToString();
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
