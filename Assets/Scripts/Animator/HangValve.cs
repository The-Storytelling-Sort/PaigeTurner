using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangValve : MonoBehaviour
{
    public GameObject hangPositionValve;
    public GameObject player;
    public float hangTime;
    private bool onValve;
    
    public Animator auriAnim;
    public ThirdPersonControllerNEW thirdPersonControllerNew;
    public AnimatorManagerNEW animatorManagerNew;
    public ChangeShape changeShape;


    private void Update()
    {
        if (auriAnim.GetBool("Hang") && onValve)
        {
            thirdPersonControllerNew.gravity = 0;
            thirdPersonControllerNew.verticalVelocity = 0;
            player.transform.position = hangPositionValve.transform.position;

            StartCoroutine(HangOn());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            onValve = true;
            changeShape.AuriShape();
            animatorManagerNew.SetHangAnimation();
        }
    }

    IEnumerator HangOn()
    {

        yield return new WaitForSeconds(hangTime);
        
        auriAnim.SetBool("Hang", false);
        thirdPersonControllerNew.gravity = -15;
        onValve = false;

    }
}
