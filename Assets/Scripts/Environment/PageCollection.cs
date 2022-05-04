using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageCollection : MonoBehaviour
{
    [Header("Page Collection 1")]
    public int pageCount;
    public int pageTotal;

    [Header("Page Collection 2")] //in case you decide to have more than 1 page section in the level
    public int pageCount2;
    public int pageTotal2;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Page")
        {
            pageCount += 1;
            Destroy(other.gameObject);
        }

        if (other.tag == "Page2") //to not confuse camera cutscenes
        {
            pageCount2 += 1;
            Destroy(other.gameObject);
        }
    }
}
