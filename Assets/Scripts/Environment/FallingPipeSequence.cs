using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPipeSequence : MonoBehaviour
{
    public Rigidbody rb;

    [SerializeField] private Animator plank;


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Environment")
        {
            FallingPipe();
            StartCoroutine(MovePlank());
        }
    }

    void FallingPipe()
    {
        GetComponent<Collider>().enabled = false;
        rb.isKinematic = false;
    }

    IEnumerator MovePlank()
    {
        yield return new WaitForSeconds(1.0f);
        plank.Play("A_Plank_Fall");
    }
}
