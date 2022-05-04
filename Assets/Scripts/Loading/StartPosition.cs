using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPosition : MonoBehaviour
{
    public GameObject start;
    public GameObject elevatorStart;

    SaveProgress saveProgress;    
    // Start is called before the first frame update
    void Start()
    {
        saveProgress = GetComponent<SaveProgress>();
        
        if (saveProgress.GetProgress("NorthWing") == 1)
            transform.position = elevatorStart.transform.position;
        else
        {
            transform.position = start.transform.position;
        }
    }
}
