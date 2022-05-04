using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAiAnimationManager : MonoBehaviour
{
    [SerializeField]
    Animator meleeAnimator;


    int animIDWalk;
    int animIDRun;
    int animIDAttack;

    void Start()
    {
        AssignAnimationIds();
    }
    void AssignAnimationIds()
    {
        animIDWalk = Animator.StringToHash("Walk");
        animIDRun = Animator.StringToHash("Run");
        animIDAttack = Animator.StringToHash("Attack");
    }
    public void SetWalkAnimation()
    {
        meleeAnimator.SetBool(animIDWalk, true);
        meleeAnimator.SetBool(animIDRun, false);
        meleeAnimator.SetBool(animIDAttack, false);
    }
    public void SetRunAnimation()
    {
        meleeAnimator.SetBool(animIDRun, true);
        meleeAnimator.SetBool(animIDWalk, false);
        meleeAnimator.SetBool(animIDAttack, false);
    }
    public void SetAttackAnimation()
    {
        meleeAnimator.SetBool(animIDAttack, true);
        StartCoroutine(Delay());

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1f);
        meleeAnimator.SetBool(animIDAttack, false);
        StopCoroutine(Delay());
    }
}
