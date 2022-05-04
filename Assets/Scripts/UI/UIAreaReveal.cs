using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIAreaReveal : MonoBehaviour
{
    public GameObject Player;

    public Animator ribbonReveal;

    public TMP_Text areaText;


    void Start()
    {
        if(ribbonReveal != null)
        {
            ribbonReveal.Play("AreaRibbon_Idle");
            areaText.text = "";
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (ribbonReveal != null)
        {
            if (other.tag == "GNOffice")
            {
                Player.GetComponent<CheckPointScript>().SetCheckPoint(other);
                ribbonReveal.Play("AreaRibbon_Reveal");
                areaText.text = "The Narrator's Office";
            }

            if (other.tag == "Archives")
            {
                Player.GetComponent<CheckPointScript>().SetCheckPoint(other);
                ribbonReveal.Play("AreaRibbon_Reveal");
                areaText.text = "The Archives";
            }

            if (other.tag == "NorthWing")
            {
                Player.GetComponent<CheckPointScript>().SetCheckPoint(other);
                ribbonReveal.Play("AreaRibbon_Reveal");
                areaText.text = "North Wing";
            }

            if (other.tag == "EastWing")
            {
                Player.GetComponent<CheckPointScript>().SetCheckPoint(other);
                ribbonReveal.Play("AreaRibbon_Reveal");
                areaText.text = "East Wing";
            }

            if (other.tag == "WestWing")
            {
                Player.GetComponent<CheckPointScript>().SetCheckPoint(other);
                ribbonReveal.Play("AreaRibbon_Reveal");
                areaText.text = "West Wing";
            }

            if (other.tag == "DestroyedArchives")
            {
                Player.GetComponent<CheckPointScript>().SetCheckPoint(other);
                ribbonReveal.Play("AreaRibbon_Reveal");
                areaText.text = "Turner";                
            }
        }
    }
}
