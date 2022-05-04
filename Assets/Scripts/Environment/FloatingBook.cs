using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBook : MonoBehaviour
{
    
    Animator anim;

    [SerializeField]
    private GameObject valve;
    ValveTurn valveCount;

    void Start()
    {
        valveCount = valve.GetComponent<ValveTurn>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (valveCount.isDrained == true)
        {
            anim.SetFloat("State", 1);
        }
    }
}
