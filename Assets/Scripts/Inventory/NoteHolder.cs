using UnityEngine;
using System.Collections;

// Imari - This class is to be attached to notes to be added to the system, the notes should be attached to box colliders
public class NoteHolder : MonoBehaviour
{
    [SerializeField]
    NoteScriptableObject note;

    AudioSource audioSource;

    #region Variables For NorthWing Specifics
    public static int pagesColleted = 0;
    #endregion

    public AudioClip Colleted;

    public BoxCollider boxCollider;
    public MeshRenderer meshRenderer;
    public new ParticleSystem particleSystem;
    public new Light light;

    void Awake()
    {
        pagesColleted = 0;
        audioSource = GetComponent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();

#if UNITY_EDITOR
        // This should only run in the Unity Editor, sets the notes to false hopefully
        note.inInventory = false;
#endif
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
           StartCoroutine(PageCollection());
        }
    }
    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    IEnumerator PageCollection()
    {
        note.inInventory = true;
        pagesColleted += 1;
        PlaySound(Colleted);
        boxCollider.enabled = false;
        meshRenderer.enabled = false;
        light.enabled = false;
        particleSystem.Stop();
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }
}
