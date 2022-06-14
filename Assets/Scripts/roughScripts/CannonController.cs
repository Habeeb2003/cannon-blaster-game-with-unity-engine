using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour {

	/*private GameObject Cannon;

	//Rotation variables
	private float rotationRate = 1.0;
	private bool wasRotating;

	//Scrolling inertia variables
	private Vector2 scrollPosition = Vector2.zero;
	private float scrollVelocity;
	private float timeTouchPhaseEnded;
	private float inertiaDuration;

	private float itemInertiaDuration = 1.0f;
	private float itemTimeTouchPhaseEnded;
	private float rotateVelocityX = 1.0f;
	private float rotateVelocityY = 1.0f;

	// Use this for initialization
	void Start () {
		Cannon = GameObject.FindGameObjectWithTag("Cannon");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 cannonPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 cannon2d = new Vector2 (cannonPos.x, cannonPos.y);

			RaycastHit2D hit = Physics2D.Raycast (cannon2d, Vector2.zero);

			if (hit.collider != null) {
				Debug.Log (hit.collider.gameObject.name);
				Destroy (hit.collider.gameObject);
				Debug.Log("gameObject destroyed");
			}

		}

	}

	void FixedUpdate(){
		if (Input.touchCount > 0) {

			Touch theTouch = Input.GetTouch (0);

			if (Input.GetTouch (0).phase == TouchPhase.Began) {
				GetComponent<transform.rotation>();
			}
			if (Input.GetTouch(0).phase == TouchPhase.Moved){
				
			}
		}
	}*/

			
}
