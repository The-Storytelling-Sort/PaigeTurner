using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameInd : MonoBehaviour
{

    [SerializeField] private GameObject start;
    [SerializeField] private GameObject end;

// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (start.transform.position != end.transform.position)
        {
            start.transform.position += (end.transform.position - start.transform.position).normalized * 2 * Time.deltaTime;
        }
    }
}
