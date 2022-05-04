using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Scriptable Objects/Dialogue")]
public class DialogueObject : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        public string characterName;
        public Sprite characterImage;
        public AudioClip audioClip;
        public float textTimer = 5f;
        [TextArea(4, 8)]
        public string dialogueText;
    }

    [Header("Insert dialogue information below:")]
    public textType type;
    public Info[] dialogueInfo;
    public bool isActive = false;
}

public enum textType
{
    Narrative,
    Tip
}