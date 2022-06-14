using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

	private Transform cannonsTrans;

	private float startingPos;

	public float rotateSpeed ;

	// Use this for initialization
	void Start () {
		cannonsTrans = GetComponent<Transform> ();
		startingPos = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {

			//Debug.Log ("SOMEWHERE HAS BEEN TOUCHED");

			Touch theTouch = Input.GetTouch (0);

			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				//GetComponent<transform.rotation> ();
				startingPos = theTouch.position.x;
				//Debug.Log ("TOUCH PHASE HAS BEGAN");

			}
			else if (Input.GetTouch (0).phase == TouchPhase.Moved) 
			{
				//Debug.Log ("TOUCH PHASE HAS MOVED");
				if (startingPos > theTouch.position.x) {
					transform.Rotate (Vector3.back, -rotateSpeed * Time.deltaTime);
					startingPos = theTouch.position.x;
					//Debug.Log ("TOUCH PHASE HAS MOVED TO THE LEFT");
				} 
				if (startingPos < theTouch.position.x) 
				{
					transform.Rotate (Vector3.back, rotateSpeed * Time.deltaTime);
					startingPos = theTouch.position.x;
					//Debug.Log ("TOUCH PHASE HAS MOVED TO THE LEFT");
				} 
			}
		}
	}

	void FixedUpdate(){
		
	}
}
