using UnityEngine;

// Imari - This class creates note objects for the Inventory System
[CreateAssetMenu(fileName = "Note", menuName = "Scriptable Objects/Note")]
public class NoteScriptableObject : ScriptableObject
{
    [Header("For ALL Pages:")]
    // Text that briefly describes a document in an inventory list, i. e. "Diary 1"
    public string noteName;
    public string menuName = "Note";
    // Checks if the object is already in the player's inventory
    public bool inInventory;
    // Image that appears when examining a document
    public Sprite noteDisplay;

    [Header("For NORMAL Pages ONLY:")]
    // Check if there is text overflow
    public bool multiPage;

    // In-depth text depicting the contents of the document
    [Tooltip("The main page display.")]
    [TextArea(4, 8)]
    public string frontPageText;

    [Tooltip("Use only if there is text override!")]
    [TextArea(4, 8)]
    public string backPageText;


}
