using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class testing : MonoBehaviour
{
    public TMP_Text pointText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        pointText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            StartCoroutine(CountPoint(50));
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            StartCoroutine(CountPoint(100));
        }
    }

    IEnumerator CountPoint(int points)
    {
        int a = 0;
        while (a < points)
        {
            score++;
            pointText.text = score.ToString();
            yield return new WaitForSeconds(0.001f);
            a++;
        }
    }
}
