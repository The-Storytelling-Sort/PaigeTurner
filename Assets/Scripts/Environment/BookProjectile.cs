using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using Random = UnityEngine.Random;

public class BookProjectile : MonoBehaviour
{
    [SerializeField] private GameObject auri;
    [SerializeField] private GameObject book;
    [SerializeField] private GameObject bookStack;
    [SerializeField] private GameObject turner;
    [SerializeField] private float speed;
    [SerializeField] private float despawnProximity;
    [SerializeField] private float falloffDistance = 0.3f;
    [SerializeField] private Material[] bookVariants;
    private float speedTime;
    private new Vector3 capturedPosition;
    private new Vector3 idlePosition;

    private float distance;
    private float capturedDistance;
    private float turnerDistance;
    public GameObject whoosh;

    private Animator anim;

    private void Awake()
    {
        //speedTime = speed * Time.deltaTime;
        idlePosition = book.transform.position;
        anim = GetComponentInChildren<Animator>();
    }

    public void Fire()
    {
        StartCoroutine(ThrowBook(book));
        anim.Play("NEWfireAnim");
    }

    void Update()
    {
        speedTime = speed * Time.deltaTime;
        distance = Vector3.Distance(auri.transform.position, book.transform.position);
        capturedDistance = Vector3.Distance(capturedPosition, book.transform.position);
        turnerDistance = Vector3.Distance(idlePosition, book.transform.position);
    }

    public void SendToPile()
    {
        Renderer rend = gameObject.GetComponentInChildren<Renderer>();

        if (rend.enabled)
        {
            rend.enabled = false;
        }

        Collider collider = gameObject.GetComponentInChildren<Collider>();

        if (collider.enabled)
        {
            collider.enabled = false;
        }
        
        transform.position = bookStack.transform.position;
        whoosh.SetActive(false);
        SwitchMaterial();
    }

    void Reactivate()
    {
        Renderer rend = gameObject.GetComponentInChildren<Renderer>();

        if (!rend.enabled)
        {
            rend.enabled = true;
        }

        Collider collider = gameObject.GetComponentInChildren<Collider>();

        if (!collider.enabled)
        {
            collider.enabled = true;
        }   
    }

    public void SendToTurner()
    {
        StartCoroutine(ReloadBook(book));
    }
    public IEnumerator ThrowBook(GameObject book)
    {
        while (distance > falloffDistance)
        {
            book.transform.position += (auri.transform.position - book.transform.position).normalized * speedTime;
            //book.transform.LookAt(auri.transform.position);
            capturedPosition = auri.transform.position;
            yield return null;
        }

        while (capturedDistance > despawnProximity)
        {
            book.transform.position += (capturedPosition - book.transform.position).normalized * speedTime;
           // book.transform.LookAt(capturedPosition);
            yield return null;
        }
        SendToPile();
    }

    public void SwitchMaterial()
    {
        int j = Random.Range(0, 5);
        Renderer rend = gameObject.GetComponentInChildren<Renderer>();
        rend.material = bookVariants[j];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("AuriHit!");
        }
    }

    public IEnumerator ReloadBook(GameObject book)
    {
        Reactivate();
        
        while (turnerDistance > despawnProximity)
        {
            book.transform.position += (idlePosition - book.transform.position).normalized * speedTime * 2;
            book.transform.LookAt(idlePosition);
            yield return null;
        }
        
        anim.Play("NEWloadedAnim");
    }
}
