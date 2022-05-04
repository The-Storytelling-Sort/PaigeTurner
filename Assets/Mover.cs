using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private GameObject top;
    [SerializeField] private GameObject bottom;
    [SerializeField] private float speed;
    [SerializeField] private float error;

    private float distanceDown;
    private float distanceUp;
    
    private float speedTime;
    public bool goingUp;

    private void Update()
    {
        distanceDown = Vector3.Distance(transform.position, bottom.transform.position);
        distanceUp = Vector3.Distance(transform.position, top.transform.position);
    }

    private void Awake()
    {
        speedTime = speed * Time.deltaTime;
    }

    private void Start()
    {
       // DecideDirection();
       //StartCoroutine(StartDelay());
    }

    public IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(1.0f);
        DecideDirection();
    }
    [ContextMenu("Decide")]
    public void DecideDirection()
    {
        if (goingUp)
        {
            MoveUp();
            goingUp = false;
        }

        else
        {
            MoveDown();
            goingUp = true;
        }
    }
    
    public void MoveDown()
    {
        StartCoroutine(Down());
    }

    public void MoveUp()
    {
        StartCoroutine(Up());
    }

    public IEnumerator Down()
    {
        while (distanceDown > error)
        {
            transform.position += (bottom.transform.position - transform.position).normalized * speedTime;
            yield return null;
        }
    }
    
    public IEnumerator Up()
    {
        while (distanceUp > error)
        {
            transform.position += (top.transform.position - transform.position).normalized * speedTime;
            yield return null;
        }
    }
    
}
