using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bricks : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D bd;
    private Animator anim;
    [SerializeField]
    private GameObject pointsTextPrefab;
    private int a, b, c, d, e, f;
    private float colValue;
    
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        bd = GetComponent<BoxCollider2D>();
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        float col = collision.relativeVelocity.magnitude;
        if (collision.gameObject.CompareTag("Ground"))
        {
            colValue += col;
            Debug.Log(col);
            Debug.Log(colValue);

            if (col >= 7.3f || colValue >= 7.3f)
            {
                anim.SetBool("fall", true);
                bd.enabled = false;
                GameObject floatText = Instantiate(pointsTextPrefab, transform.position, Quaternion.identity);
                floatText.transform.GetChild(0).GetComponent<TextMesh>().text = "10";
                ScoreManager.instance.CallCoroutine(10);
                Debug.Log("fall");
                Destroy(this.gameObject, 0.8f);
            }
            else if (col >= 5.5f || colValue >= 5.5f)
            {
                GameObject floatText = Instantiate(pointsTextPrefab, transform.position, Quaternion.identity);
                floatText.transform.GetChild(0).GetComponent<TextMesh>().text = "5";
                ScoreManager.instance.CallCoroutine(5);
                Debug.Log("third");
                anim.SetBool("third", true);
            }
            else if (col >= 3.5f || colValue >= 3.5f)
            {
                GameObject floatText = Instantiate(pointsTextPrefab, transform.position, Quaternion.identity);
                floatText.transform.GetChild(0).GetComponent<TextMesh>().text = "3";
                ScoreManager.instance.CallCoroutine(3);
                Debug.Log("second");
                anim.SetBool("second", true);
            }
        }
        
        if (collision.gameObject.CompareTag("projectile"))
        {
            colValue += col;
            if (col >= 7 || colValue >= 7)
            {
                anim.SetBool("explode", true);
                bd.enabled = false;
                GameObject floatText = Instantiate(pointsTextPrefab, transform.position, Quaternion.identity);
                floatText.transform.GetChild(0).GetComponent<TextMesh>().text = "10";
                ScoreManager.instance.CallCoroutine(10);
                Destroy(this.gameObject, 0.8f);
            }
            else if (col >= 5.5f || colValue >= 5.5f)
            {
                GameObject floatText = Instantiate(pointsTextPrefab, transform.position, Quaternion.identity);
                floatText.transform.GetChild(0).GetComponent<TextMesh>().text = "5";
                ScoreManager.instance.CallCoroutine(5);
                anim.SetBool("third", true);
            }
            else if (col >= 3 || colValue >= 3)
            {
                GameObject floatText = Instantiate(pointsTextPrefab, transform.position, Quaternion.identity);
                floatText.transform.GetChild(0).GetComponent<TextMesh>().text = "3";
                ScoreManager.instance.CallCoroutine(3);
                anim.SetBool("second", true);
            }
        }
        

    }
}
