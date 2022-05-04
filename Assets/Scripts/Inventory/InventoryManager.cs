using System.Collections.Generic;
using UnityEngine;

// Imari - This class is to be attached to the Player prefab to act to as manager for the notes in the environment and the UI
public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    List<NoteScriptableObject> noteIndex;

    [SerializeField]
    GameObject InventoryMenu;

    [SerializeField]
    InventoryControl[] controlIndex;

    void Awake()
    {
        Init();
    }

    void Init()
    {
        controlIndex = InventoryMenu.GetComponentsInChildren<InventoryControl>();

        int index = 0;

        foreach (NoteScriptableObject note in noteIndex)
        {
            controlIndex[index].noteObject = note;
            index++;
        }
    }
}
