using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnim : MonoBehaviour
{
    [SerializeField] private Animator anim;
    
    [ContextMenu("Forwards")]
    public void Forwards()
    {
        anim.Play("PageFlipForwards");
    }
    
    [ContextMenu("Backwards")]

    public void Backwards()
    {
        anim.Play("PageFlipBackwards");
    }

    [ContextMenu("Close")]

    public void CloseBook()
    {
        anim.Play("CloseBook");
    }
}
