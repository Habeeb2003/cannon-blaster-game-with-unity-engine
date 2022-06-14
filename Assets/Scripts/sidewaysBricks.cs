using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sidewaysBricks : MonoBehaviour
{

    private Component[] rb;
    [SerializeField]
    private List<GameObject> gO;
    private int childrenNo;
    private bool hasExit = false;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponentsInChildren<Rigidbody2D>();
        foreach (Rigidbody2D item in rb)
        {
            gO.Add(item.gameObject);
            item.isKinematic = true;
        }
        foreach (var item in gO)
        {
            if (item.GetComponent<EnaSideBricksRb>() == null)
            {
                item.gameObject.AddComponent<EnaSideBricksRb>();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject != null && hasExit == false)
        {
            Debug.Log(collision.gameObject);
            for (int i = 0; i < gO.Count; i++)
            {
                if (collision.gameObject.name == gO[i].name)
                {
                    hasExit = true;
                    //this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                    //gO.Remove(collision.gameObject);
                    StartCoroutine(WaitToFall());
                    return;
                }

            }
        }
        
    }

    IEnumerator WaitToFall()
    {
        while (gO.Count > 0)
        {
            if (gO[0].GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Dynamic)
            {
                yield return new WaitForSeconds(0.2f);
                gO[0].GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            gO.RemoveAt(0);
        }
    }
}
