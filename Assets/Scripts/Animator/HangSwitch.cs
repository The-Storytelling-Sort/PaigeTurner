using System.Collections;
using UnityEngine;

public class HangSwitch : MonoBehaviour
{
    public GameObject hangPositionVent;
    public GameObject player;
    public float hangTime;
    private bool onSwitch;
    
    public Animator auriAnim;
    public ThirdPersonControllerNEW thirdPersonControllerNew;
    public AnimatorManagerNEW animatorManagerNew;
    public VentSwitchOnOff ventSwitchOnOff;
    public ChangeShape changeShape;
    
    private void Update()
    {
        if (auriAnim.GetBool("Hang") && onSwitch)
        {
            thirdPersonControllerNew.gravity = 0;
            thirdPersonControllerNew.verticalVelocity = 0;
            StartCoroutine(HangOn());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && ventSwitchOnOff.isOff)
        {
            onSwitch = true;
            changeShape.AuriShape();
            animatorManagerNew.SetHangAnimation();
        }
    }

    IEnumerator HangOn()
    {
        player.transform.position = hangPositionVent.transform.position;

        yield return new WaitForSeconds(hangTime);
        
        auriAnim.SetBool("Hang", false);
        thirdPersonControllerNew.gravity = -15;
        onSwitch = false;

    }
}
