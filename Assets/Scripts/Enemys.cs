using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemys : MonoBehaviour
{
	public GameObject _cloudParticlePrefab;
	public GameObject pointsTextPrefab;
	//private Animator anim;
	//private float whenToJump;
	//private float startTimeToJump = 0;

    private void Start()
    {
		//anim = GetComponent<Animator>();
		//RandomJumpTime();
    }
    private void Update()
    {
		//startTimeToJump += Time.deltaTime;
  //      if (startTimeToJump >= whenToJump)
  //      {
		//	anim.SetTrigger("jump");
		//	RandomJumpTime();
		//	startTimeToJump = 0;
		//	print("wor");
  //      }
    }
	//void RandomJumpTime()
 //   {
	//	float random = Random.Range(8f, 20f);
	//	whenToJump = random;
 //   }
    private void OnCollisionEnter2D(Collision2D collision)
	{
		Enemys enemy = collision.collider.GetComponent<Enemys>();
		if (enemy != null)
		{
			return;
		}
		if (collision.collider.CompareTag("projectile"))
        {
			Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
			GameObject floatText = Instantiate(pointsTextPrefab, transform.position, Quaternion.identity);
			floatText.transform.GetChild(0).GetComponent<TextMesh>().text = "50";
			ScoreManager.instance.CallCoroutine(50);
			gameObject.SetActive(false);
		}
		else if (collision.contacts[0].normal.y < -0.5)
		{
			Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
			ScoreManager.instance.CallCoroutine(50);
			gameObject.SetActive(false);
		}
	}

}
