using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookAnimScript : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [ContextMenu("FirstFlip")]
    public void FirstAnim()
    {
        Debug.Log("Animation Triggered");
        anim.Play("Pages|Flip 2");
    }
    
    [ContextMenu("SecondFlip")]
    public void SecondAnim()
    {
        anim.Play("Pages|Flip 3");
    }
    
    [ContextMenu("ThirdFlip")]
    public void ThirdAnim()
    {
        anim.Play("Pages|Flip 4");
    }
    
    [ContextMenu("FourthFlip")]
    public void FourthAnim()
    {
        anim.Play("Pages|Flip 5");
    }
}
