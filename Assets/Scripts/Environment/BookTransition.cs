using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookTransition : MonoBehaviour
{
    [SerializeField]
    Animator sceneTransition;
    [SerializeField]
    GameObject openBook;
    [SerializeField]
    GameObject bookStack;
    [SerializeField]
    GameObject[] propsDisable;

    // Start is called before the first frame update
    void Start()
    {
        openBook.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(FadeScreen());
            Debug.Log("Fade!");
        }
    }

    IEnumerator FadeScreen()
    {
        sceneTransition.Play("A_Transition_FadeOut");
        yield return new WaitForSeconds(3.5f);
        sceneTransition.Play("A_Transition_FadeIn");
        OpenBook();
    }

    void OpenBook()
    {
        openBook.SetActive(true);
        bookStack.SetActive(true);
        foreach (GameObject prop in propsDisable)
        {
            prop.SetActive(false);
        }
        this.gameObject.SetActive(false);
    }
}
