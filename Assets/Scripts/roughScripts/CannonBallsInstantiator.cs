using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallsInstantiator : MonoBehaviour {

	public Transform instPos;

	public GameObject CannonBall;

	private Rigidbody2D BallRb;

	public float velocity;

	// Use this for initialization
	void Start () {
		CannonBall = GameObject.FindWithTag ("Ball");
		BallRb = CannonBall.GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			Debug.Log ("ball instanstiated");
			Instantiate (CannonBall, instPos);
			BallRb.AddForce ((new Vector3(0,0, transform.rotation.z)) * velocity);
		}
	}
}
