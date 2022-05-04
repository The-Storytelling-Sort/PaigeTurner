using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundtrackManager : MonoBehaviour
{
   // public AudioSource TurnersOffice;
    public AudioSource GrandArchives;
    public AudioSource Elevator;
    public AudioSource DramaSection;

    public bool TO;
    public bool GA;
    public bool EV;
    public bool DS;

    public float FadeTime = 1.5f;
    public float timeElapsed;

    void Start()
    {
       // TurnersOffice.Play();
       if (GrandArchives != null)
       {
           GrandArchives.Play();
           GrandArchives.volume = 0.1f;
       }
       
       if (Elevator != null)
       {
           Elevator.Play();
           Elevator.volume = 0.0f;
       }

       if (DramaSection != null)
       {
           DramaSection.Play();
           DramaSection.volume = 0.0f;
       }
       
       // TurnersOffice.volume = 0.1f;
        //TO = true;
    }


    void Update()
    {
        if (GA)
        {
            if (timeElapsed < FadeTime)
            {
                //if (TurnersOffice.volume > 0.0f)
                //{
                //    TurnersOffice.volume = Mathf.Lerp(0.1f, 0, timeElapsed / FadeTime);
                //    timeElapsed += Time.deltaTime;
                //}

                if (Elevator.volume > 0.0f)
                {
                    Elevator.volume = Mathf.Lerp(0.1f, 0, timeElapsed / FadeTime);
                    timeElapsed += Time.deltaTime;
                }
            }

            else
            {
                GrandArchives.volume = Mathf.Lerp(0, 0.1f, timeElapsed / FadeTime);
                timeElapsed += Time.deltaTime;
            }
        }

        //if (TO)
        //{
        //    if (timeElapsed < FadeTime)
        //    {
        //        GrandArchives.volume = Mathf.Lerp(0.1f, 0, timeElapsed / FadeTime);
        //        timeElapsed += Time.deltaTime;
        //    }

        //    else
        //    {
        //        TurnersOffice.volume = Mathf.Lerp(0, 0.1f, timeElapsed / FadeTime);
        //        timeElapsed += Time.deltaTime;
        //    }
        //}

        if (EV)
        {
            if (timeElapsed < FadeTime)
            {
                if (GrandArchives.volume > 0.0f)
                {
                    GrandArchives.volume = Mathf.Lerp(0.1f, 0, timeElapsed / FadeTime);
                    timeElapsed += Time.deltaTime;
                }

                if (DramaSection.volume > 0.0f)
                {
                    DramaSection.volume = Mathf.Lerp(0.1f, 0, timeElapsed / FadeTime);
                    timeElapsed += Time.deltaTime;
                }
            }

            else
            {
                Elevator.volume = Mathf.Lerp(0, 0.1f, timeElapsed / FadeTime);
                timeElapsed += Time.deltaTime;
            }
        }

        if (DS)
        {
            if (timeElapsed < FadeTime)
            {
                Elevator.volume = Mathf.Lerp(0.1f, 0, timeElapsed / FadeTime);
                timeElapsed += Time.deltaTime;
            }

            else
            {
                DramaSection.volume = Mathf.Lerp(0, 0.1f, timeElapsed / FadeTime);
                timeElapsed += Time.deltaTime;
            }
        }
    }
}
