using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold;

	// Use this for initialization
	void Start () {
		standingThreshold = 3f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public bool IsStanding(){
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		float tiltInX = Mathf.Abs(rotationInEuler.x);
		// Y is rotation around the central axis of the pin. which is irrelevant. it still stands.
		float tiltInZ = Mathf.Abs(rotationInEuler.z);
		// abs makes it so that -10 degrees = 350 degrees.

		if(tiltInX  < standingThreshold && tiltInZ < standingThreshold){
			return true;
		}

		return false;

	}

}
