using System;
using UnityEngine;
using System.Collections;

public class AnimatorManagerNEW : MonoBehaviour
{
    [HideInInspector]
    public float animationBlend;
    [HideInInspector]
    public bool hasAnimator;

    int animIDSpeed;
    int animIDGrounded;
    int animIDJump;
    int animIDFreeFall;
    int animIDMotionSpeed;
    int animIDx;
    int animIDy;
    int animIDClimb;
    int animIDHit;
    int animIDDead;
    int animIDHang;
    int animIDIdleWave;

    Animator animator;
    ThirdPersonControllerNEW thirdPersonController;
    InputManagerNEW inputManager;

    void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonControllerNEW>();
        inputManager = GetComponent<InputManagerNEW>();
    }

    void Start()
    {
        hasAnimator = TryGetComponent(out animator);
        AssignAnimationIDs();
    }

    void AssignAnimationIDs()
    {
        animIDSpeed = Animator.StringToHash("Speed");
        animIDGrounded = Animator.StringToHash("Grounded");
        animIDJump = Animator.StringToHash("Jump");
        animIDFreeFall = Animator.StringToHash("FreeFall");
        animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
        animIDx = Animator.StringToHash("x");
        animIDy = Animator.StringToHash("y");
        animIDClimb = Animator.StringToHash("Climb");
        animIDHit = Animator.StringToHash("Hit");
        animIDDead = Animator.StringToHash("Dead");
        animIDHang = Animator.StringToHash("Hang");
        animIDIdleWave = Animator.StringToHash("IdleWave");
    }

    public void SetGroundedAnimation()
    {
        animator.SetBool(animIDGrounded, thirdPersonController.grounded);
        animator.SetBool(animIDJump, false);
        animator.SetBool(animIDFreeFall, false);
        animator.SetBool(animIDClimb, false);
        //animator.SetBool(animIDHang, false);


    }

    public void SetJumpAnimation()
    {
        animator.SetBool(animIDJump, true);
        //animator.SetBool(animIDClimb, false);
        
    }

    public void SetFallAnimation()
    {
        animator.SetBool(animIDFreeFall, true);
        animator.SetBool(animIDClimb, false);
        //animator.SetBool(animIDHang, false);

    }

    public void SetClimbAnimation()
    {
        animator.SetBool(animIDClimb, true);
        animator.SetBool(animIDGrounded, false);
    }

    public void SetHitAnimation()
    {
        animator.SetBool(animIDHit, true);
        StartCoroutine(IsHit(1.3f));

    }
    public void SetDeadAnimation()
    {
        animator.SetBool(animIDDead, true);
        StartCoroutine(IsDead(1.2f));
    }
    
    public void SetHangAnimation()
    {
        animator.SetBool(animIDHang, true);
        animator.SetBool(animIDFreeFall, false);
    }
    public void SetIdleWave()
    {
        animator.SetBool(animIDIdleWave, true);
        
    }
    public void SetIdleWaveFalse()
    {
        animator.SetBool(animIDIdleWave, false);
    }

    public void BlendAnimations()
    {
        animationBlend = Mathf.Lerp(animationBlend, thirdPersonController.targetSpeed, Time.deltaTime * thirdPersonController.speedChangeRate);
        animator.SetFloat(animIDSpeed, animationBlend);
        animator.SetFloat(animIDMotionSpeed, thirdPersonController.inputMagnitude);
    }

    public void BlendClimbAnimations()
    {
        animationBlend = Mathf.Lerp(animationBlend, thirdPersonController.moveSpeed, Time.deltaTime * thirdPersonController.speedChangeRate);
        animator.SetFloat(animIDx, inputManager.horizontalInput);
        animator.SetFloat(animIDy, inputManager.verticalInput);
        animator.SetFloat(animIDMotionSpeed, thirdPersonController.inputMagnitude);
    }

    IEnumerator IsHit(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        animator.SetBool(animIDHit, false);
        StopCoroutine(IsHit(0));
        yield break;
    }
    IEnumerator IsDead(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        animator.SetBool(animIDDead, false);
        StopCoroutine(IsDead(0));
        yield break;
    }
    IEnumerator IsIdleWaving(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        animator.SetBool(animIDIdleWave, false);
        StopCoroutine(IsIdleWaving(0));
        yield break;
    }
}
