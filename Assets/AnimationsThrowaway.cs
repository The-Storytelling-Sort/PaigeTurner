using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationsThrowaway : MonoBehaviour
{
    [SerializeField] private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("ThrowAnim")]
    void RightThrow()
    {
        anim.Play("RightRaise");
    }
}
