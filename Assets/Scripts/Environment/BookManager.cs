using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BookManager : MonoBehaviour
{
    #region Variables
    public Transform bookArea;
    public Transform worldArea;
    public GameObject Player;
    public GameObject PlayerModel;

    private CameraChecker camerachecker;
    #endregion

    #region Awake
    private void Awake()
    {
        camerachecker = GameObject.FindObjectOfType<CameraChecker>();
    }
    #endregion

    #region Update
    void Update()
    {
        if (camerachecker.is2D)
        {

            Invoke("Teleport", 2);
        }

        if (camerachecker.is3D)
        {
            Invoke("worldTeleport", 0);
        }

    
    }
    #endregion 

    public void Teleport()
    {
        Player.transform.position = bookArea.transform.position;
        PlayerModel.transform.position = bookArea.transform.position;
        //Teleport to Book.
    }

    public void worldTeleport()
    {
        Player.transform.position = worldArea.transform.position;
        PlayerModel.transform.position = worldArea.transform.position;
        //Teleport Back to World.
    }

}
