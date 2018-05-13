using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Vector3 launchVelocity;
	public bool launched;

	private Rigidbody rigidBody;
	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		audioSource = GetComponent<AudioSource> ();

		rigidBody.useGravity = false; // so the ball doesn't fall before we launch it
		launched = false;

	}

	public void Launch (Vector3 velocity)
	{	
		launched = true;
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;

		audioSource.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
