using UnityEngine;
using UnityEngine.Video;

// This class is created as an extension to the regular inventory note objects in order to function in the same menu.
[CreateAssetMenu(fileName = "Tutorial", menuName = "Scriptable Objects/Tutorial Page")]
public class TutorialPage : NoteScriptableObject
{
    [Header("For TUTORIAL Pages ONLY:")]

    public string displayTitle;
    public VideoClip displayClip;

    [TextArea(4, 8)]
    public string displayText;
    public bool trigger = false;
}
