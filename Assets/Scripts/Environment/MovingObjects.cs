using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjects : MonoBehaviour
{
    public GameObject[] Points;

    int CurrentPoint = 0;

    public float Speed;

    float PointRadius = 1;

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Points[CurrentPoint].transform.position, transform.position) < PointRadius)
        {
            CurrentPoint++;

            if(CurrentPoint >= Points.Length)
            {
                CurrentPoint = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, Points[CurrentPoint].transform.position, Time.deltaTime * Speed);
    }
}
