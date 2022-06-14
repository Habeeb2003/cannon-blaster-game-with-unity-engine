using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Cinemachine;

public class GameManager : MonoBehaviour {

	public GameManager instance;

	Rigidbody2D rb;
	bool hasHit = false;

	public float lauchForce;

	public GameObject projectilePrefab;
	public Image bgImage;
	public GameObject Instpos;

	//// UI part of game
	public Button fireButton;
	public GameObject gameOverCanvas;
	public Canvas gameCanvas;
	public GameObject levelCompleteCanvas;
	private bool hasShowedAddProDialogue;
	public Image[] stars;
	[SerializeField] private RawImage[] starsPartiUI;
	[SerializeField] private ParticleSystem starsParticles;
	private bool oneTime = false;

	public List<Image> availabeProjectiles;
	public GameObject AddProjectileDialogue;
	Image bbb;
	//public Button goBackButton;

	private GameObject BallIns;

	public List<GameObject> projectiles;
	private bool _projectileWasLaunched;
	private float _timeSittingAround;
	private float _timeafterlaunch;

	int inde;
	public GameObject particleCamera;
	private float on;
	private bool boole = false;

    private void Awake()
    {
		instance = this;
    }
    // Use this for initialization
    void Start () {
		rb = projectilePrefab.GetComponent<Rigidbody2D>();
		NewGame();
		
	}
	
	public void NewGame()
    {
		AvailableProjectilesUI(3);
		levelCompleteCanvas.SetActive(false);
		gameOverCanvas.SetActive(false);
		AddProjectileDialogue.SetActive(false);
		hasShowedAddProDialogue = false;
		inde = 0;
	}

	private void AvailableProjectilesUI(int Num)
    {
		for (int i = 0; i < Num; i++)
		{
			availabeProjectiles[i].GetComponentsInChildren<Image>()[1].gameObject.GetComponent<Image>().enabled = true;
			availabeProjectiles[i].GetComponentsInChildren<Image>()[1].gameObject.SetActive(true);
			availabeProjectiles[i].sprite = projectiles[i].GetComponent<SpriteRenderer>().sprite;
			Component[] comp = availabeProjectiles[i].GetComponentsInChildren<Image>();
			for (int j = 1; j < comp.Length; j++)
			{
				comp[j].gameObject.GetComponent<Image>().sprite = projectiles[i].GetComponent<SpriteRenderer>().sprite;
			}
		}
	}
	// Update is called once per frame
	void Update () {
        if (BallIns != null)
        {
            if (_projectileWasLaunched)
            {
				_timeafterlaunch += Time.deltaTime;
            }
			if (_projectileWasLaunched && BallIns.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.3 
				|| BallIns.transform.position.x < -16)
			{
				_timeSittingAround += Time.deltaTime;
			}
			
			if (_timeSittingAround >= 2)
			{
				Destroy(BallIns);
				_timeSittingAround = 0;
				_timeafterlaunch = 0;
				fireButton.gameObject.SetActive(true);
			}
            if (_timeafterlaunch > 5 && BallIns.transform.position.x > 0)
            {
				Destroy(BallIns);
				_timeSittingAround = 0;
				_timeafterlaunch = 0;
				fireButton.gameObject.SetActive(true);
			}
		}
        if (projectiles.Count == 0 && BallIns == null)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                if (oneTime == false)
                {
					CheckStarsBool("EnemiesAndCompleted");
					levelCompleteCanvas.SetActive(true);
					oneTime = true;
				}
            }
            else if (GameObject.FindGameObjectsWithTag("Enemy").Length >= 1)
            {
                if (hasShowedAddProDialogue == false)
                {
					ShowAddProDialogue();
				}
				else if (hasShowedAddProDialogue == true)
                {
					//CheckStarsBool("")
					gameOverCanvas.SetActive(true);
                }
            }
			fireButton.gameObject.SetActive(false);
        }
		if (CrossPlatformInputManager.GetButtonDown("Fire1"))
		{
			//shoot
			Shoot();
		}
		if (CrossPlatformInputManager.GetButtonUp("Fire1"))
		{
			//disable the button
			fireButton.gameObject.SetActive(false);
			//check if the ball has stopped rolling
		}
		if (hasHit == true) {
			trackMovement ();
		}
	}

	void Shoot()
	{
		GameObject mass = projectiles[0];
		BallIns = Instantiate(mass, Instpos.transform.position, Quaternion.identity);
		projectiles.RemoveAt(0);
		availabeProjectiles[inde].GetComponentsInChildren<Image>()[1].gameObject.GetComponent<Image>().enabled = false;
		// apply force to the ball we just created
		BallIns.GetComponent<Rigidbody2D>().velocity = CannonScript.direction.normalized * -lauchForce;
		float BallInsXPos = BallIns.transform.position.x;
		_projectileWasLaunched = true;
		inde += 1;
	}

	void trackMovement(){
		Vector2 direction = rb.velocity;
		float angle = Mathf.Atan2 (direction.y, direction.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward); //Applying the angle we just calculated
	}

	void OnCollision2d(Collision2D col){
		//if the ball has hit something
		hasHit = true;
	}
	void ShowAddProDialogue()
    {
		Time.timeScale = 0;
		AddProjectileDialogue.SetActive(true);
    }
	public void AddProjectilesButtons(string param)
    {
        if (param == "Watch Ads")
        {
			projectiles.Add(projectilePrefab);
			AvailableProjectilesUI(1);
			AddProjectileDialogue.SetActive(false);
			fireButton.gameObject.SetActive(true);
			inde = 0;
			hasShowedAddProDialogue = true;
			Time.timeScale = 1;
		}
        else if (param == "Quit Anyways")
        {
			hasShowedAddProDialogue = true;
			AddProjectileDialogue.SetActive(false);
		}
	}
	void CheckStarsBool(string action)
    {
        for (int i = 0; i < Scene1LevelsRequirementManager.instance.LR_Array.Length; i++)
        {
            if (action == "EnemiesAndCompleted")
            {
				if (Scene1LevelsRequirementManager.instance.LR_Array[i].levelName == SceneManager.GetActiveScene().name)
				{
					Scene1LevelsRequirementManager.instance.LR_Array[i].allEnemiesKilled = true;
					Scene1LevelsRequirementManager.instance.LR_Array[i].levelCompleted = true;
                    if (ScoreManager.score >= Scene1LevelsRequirementManager.instance.LR_Array[i].requiredPoints)
                    {
						Scene1LevelsRequirementManager.instance.LR_Array[i].requiredPointsPassed = true;
					}
				}
			}
		}
		ShowStars();
    }
	void ShowStars()
	{
		StartCoroutine(StarsDelay());
		
	}
	IEnumerator StarsDelay()
	{
		print(0);
		int starIndex = 0;

		for (int i = 0; i<Scene1LevelsRequirementManager.instance.LR_Array.Length; i++)
		{
			if (Scene1LevelsRequirementManager.instance.LR_Array[i].levelName == SceneManager.GetActiveScene().name)
			{
                if (Scene1LevelsRequirementManager.instance.LR_Array[i].allEnemiesKilled == true)
                {
					print(1);
					yield return new WaitForSeconds(1f);
					stars[starIndex].gameObject.SetActive(true);
					starsPartiUI[starIndex].texture = particleCamera.GetComponent<RenderParticlesEffect>().renderTexture;
					starsParticles.Play();
					starIndex++;
                }
				if (Scene1LevelsRequirementManager.instance.LR_Array[i].levelCompleted == true)
				{
					print(2);
					yield return new WaitForSeconds(1f);
					stars[starIndex].gameObject.SetActive(true);
					starsParticles.Stop();
					starsPartiUI[starIndex - 1].gameObject.SetActive(false);
					starsPartiUI[starIndex].texture = particleCamera.GetComponent<RenderParticlesEffect>().renderTexture;
					starsParticles.Play();
					starIndex++;
				}
				if (Scene1LevelsRequirementManager.instance.LR_Array[i].requiredPointsPassed == true)
				{
					print(3);
					yield return new WaitForSeconds(1f);
					stars[starIndex].gameObject.SetActive(true);
					starsParticles.Stop();
					starsPartiUI[starIndex - 1].gameObject.SetActive(false);
					starsPartiUI[starIndex].texture = particleCamera.GetComponent<RenderParticlesEffect>().renderTexture;
					starsParticles.Play();
					//yield return new WaitForSeconds(1f);
					//starsPartiUI[starIndex].gameObject.SetActive(false);
				}
				break;
			}
		}
    }

	private void Kkkk()
    {

    }
}
