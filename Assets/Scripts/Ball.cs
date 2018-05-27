using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;
	public bool launched;

	private Rigidbody rigidBody;
	private AudioSource audioSource;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();

		rigidBody.useGravity = false; // so the ball doesn't fall before we launch it
		launched = false;
		startPosition = transform.position;

	}

	public void Launch (Vector3 velocity)
	{	
		launched = true;
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;

		audioSource.Play ();
	}

	public void Reset(){
		launched = false;
		rigidBody.useGravity = false;
		rigidBody.velocity = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		transform.position = startPosition;
		transform.rotation = Quaternion.identity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
