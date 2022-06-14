using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class ShootScript : MonoBehaviour {

	public float lauchForce;

	public GameObject CannonBall;
	public GameObject cannon;

	public GameObject Instpos;

	public bool fire1Active = true;

	public Canvas fireCanvas;

	
	// Use this for initialization
	void Start () {
		Instpos = GameObject.FindGameObjectWithTag("InstPos");
	}
	
	// Update is called once per frame
	void Update () {
		if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
			//shoot
			Shoot();
        }
		if (CrossPlatformInputManager.GetButtonUp("Fire1"))
		{
			//disable the button
			fireCanvas.enabled = false;

			//check if the ball has stopped rolling
		}
	}

	void Shoot(){
		GameObject BallIns = Instantiate (CannonBall, Instpos.transform.position, cannon.transform.rotation);

		// apply force to the ball we just created
		BallIns.GetComponent<Rigidbody2D>().velocity = transform.right * -lauchForce;
	}

}
