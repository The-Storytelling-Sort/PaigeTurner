using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAiAnimationManager : MonoBehaviour
{
    [SerializeField]
    Animator rangedAnimator;


    int animIDWalk;
    int animIDRun;
    int animIDAttack;
    int animIDDodge;

    void Start()
    {
        AssignAnimationIds();
    }
    void AssignAnimationIds()
    {
        animIDWalk = Animator.StringToHash("Walk");
        animIDRun = Animator.StringToHash("Run");
        animIDAttack = Animator.StringToHash("Attack");
        animIDDodge = Animator.StringToHash("Dodge");
    }
    public void SetWalkAnimation()
    {
        rangedAnimator.SetBool(animIDWalk, true);
        rangedAnimator.SetBool(animIDRun, false);
        rangedAnimator.SetBool(animIDDodge, false);
        rangedAnimator.SetBool(animIDAttack, false);
    }
    public void SetRunAnimation()
    {
        rangedAnimator.SetBool(animIDRun, true);
        rangedAnimator.SetBool(animIDWalk, false);
        rangedAnimator.SetBool(animIDDodge, false);
    }
    public void SetAttackAnimation()
    {
        rangedAnimator.SetBool(animIDAttack, true);
        rangedAnimator.SetBool(animIDDodge, false);
    }
    public void SetDodgeAnimation()
    {
        rangedAnimator.SetBool(animIDDodge, true);
        rangedAnimator.SetBool(animIDRun, false);
        rangedAnimator.SetBool(animIDWalk, false);
        rangedAnimator.SetBool(animIDAttack, false);
    }
}

