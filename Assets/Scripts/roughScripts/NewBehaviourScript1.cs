using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Wait());
		print(2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Wait()
    {
		yield return new WaitForSeconds(3f);
		print("22");
    }
}
