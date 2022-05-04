using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

[RequireComponent(typeof(AudioSource))]
public class BookHolder : MonoBehaviour
{
    [SerializeField] public List<GameObject> books = new List<GameObject>();
    [SerializeField] private GameObject[] booksReload;
    [SerializeField] private GameObject turner;
    [SerializeField] private GameObject turnerPosition;
    [SerializeField] private float waitTime;
    [SerializeField] private float fireTime;
    [SerializeField] private float reloadTime;
    [SerializeField] private float animDelay;
    [SerializeField] private Animator turnerAnimator;
    [SerializeField] private float cutsceneTimer;
    [SerializeField] private GameObject[] grunts;
    [SerializeField] private GameObject[] reloads;

    private List<int> randNumber;

    private void Start()
    {
        StartCoroutine(DelayedStart());
    }

    public IEnumerator DelayedStart()
    {
        yield return new WaitForSeconds(cutsceneTimer);
        StartCoroutine(ShootBooks());
    }
    
    public IEnumerator ShootBooks()
    {
        for (int i = 0; i < 6; i++)
        {
            StartCoroutine(TurnerAnim());
            yield return new WaitForSeconds(waitTime);
            int j = Random.Range(0, books.Count -1);
            books[j].GetComponent<BookProjectile>().Fire();
            books[j].GetComponent<BookProjectile>().whoosh.SetActive(true);
            int f = Random.Range(0, 2);
            grunts[f].gameObject.GetComponent<AudioSource>().Play();
            books.RemoveAt(j);

            if (books.Count <= 0)
            {
                for (int k = 0; k < 6; k++)
                {
                    books.Add(booksReload[k]);
                }
                yield return new WaitForSeconds(animDelay);
                turnerAnimator.Play("Refill");
                yield return new WaitForSeconds(reloadTime);
                StartCoroutine(RecallBooks());
            }
        }
    }

    public IEnumerator RecallBooks()
    {
        // Reload anim here.
        int g = Random.Range(0, 1);
        reloads[g].gameObject.GetComponent<AudioSource>().Play();
        for (int a = 0; a < 6; a++)
        {
            books[a].GetComponent<BookProjectile>().SendToTurner();
        }
        //reloadTime wait here.
        StartCoroutine(ShootBooks());
        yield return null;
    }

    public IEnumerator TurnerAnim()
    {
        //fireTime should be the amount of time it takes for there to be around 2 seconds left in waitTime
        yield return new WaitForSeconds(fireTime);
        turnerAnimator.Play("RightFire");
        turner.transform.position = turnerPosition.transform.position;

    }
}
