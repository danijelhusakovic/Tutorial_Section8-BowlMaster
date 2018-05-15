using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit(Collider collider){
		if(collider.gameObject.GetComponent<Pin>()){
			Destroy (collider.gameObject);
		}
	}

}
