using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonScript : MonoBehaviour {

	public static Vector2 direction;
	public static Quaternion thisQuar;

	public GameObject projectileInstantiator;
	public GameObject trajectObject;

	// Use this for initialization
	void Start () {

		direction.x = 2.0f;
		direction.y = 0.0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		thisQuar = this.transform.rotation;
        if (Input.touchCount > 0)
        {

			Touch touch = Input.GetTouch(0);
			Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            if (touchPos.x > 2)
            {
				if (touch.phase == TouchPhase.Moved)
				{
					Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
					Vector2 CannonPos = transform.position;

					direction = MousePos - CannonPos; // calculate the direction
					transform.right = direction;
					trajectObject.GetComponent<trajectory>().Traject();
				}
			}
        }
		else
		{
			trajectObject.GetComponent<trajectory>().StopTrajectory();
		}
		FaceMouse();
	}

	void FaceMouse(){
		transform.right = direction;
	}

	
}
