using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	public static ScoreManager instance;
    public TMP_Text  scoreText;
    public static int score = 0;

    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text =  score.ToString();
    }
    public void CallCoroutine(int points)
    {
        StartCoroutine(CountPoints(points));
    }
	public IEnumerator CountPoints(int points)
	{
		int a = 0;
		while (a < points)
		{
			score++;
			yield return new WaitForSeconds(0.00001f);
			a++;
		}
	}
}
