using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trajectory : MonoBehaviour
{

    public float force;

    public GameObject PointPrefab;
    public Sprite pointSprite;

    public GameObject[] Points;

    public int numberOfPoints;
    public GameObject cannon;
    


    // Start is called before the first frame update
    void Start()
    {
        force = FindObjectOfType<GameManager>().lauchForce;
        Points = new GameObject[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            Points[i] = Instantiate(PointPrefab);
            Points[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
        
    }

    public void Traject()
    {
        for (int i = 0; i < Points.Length; i++)
        {
            Points[i].SetActive(true);
        }
        for (int i = 0; i < Points.Length; i++)
        {
            
            if (Physics2D.IsTouching(Points[i].GetComponent<CircleCollider2D>(), GameObject.FindGameObjectWithTag("Ground").GetComponent<BoxCollider2D>())) 
            {
                Points[i].GetComponent<SpriteRenderer>().sprite = null;
            }
            else
            {
                Points[i].GetComponent<SpriteRenderer>().sprite = pointSprite;
            }
            Points[i].transform.position = PointPosition(i * 0.07f);
        }
        
    }

    public void StopTrajectory()
    {
        for (int i = 0; i < Points.Length; i++)
        {
            
            Points[i].SetActive(false);
        }
    }

    Vector2 PointPosition(float t)
    {
        Vector2 currentPointPos = (Vector2)transform.position + (CannonScript.direction.normalized * -force * t) + 0.5f * Physics2D.gravity * (t * t);
        return currentPointPos;
    }
}
