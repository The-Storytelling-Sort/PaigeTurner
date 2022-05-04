using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public static class CameraSwitcher 
{
    static List<CinemachineVirtualCameraBase> cameras = new List<CinemachineVirtualCameraBase>();

    public static CinemachineVirtualCameraBase ActiveCamera = null;

    public static bool IsActiveCamera(CinemachineVirtualCameraBase camera)
    {
        return camera == ActiveCamera;
    }

    public static void SwitchCamera(CinemachineVirtualCameraBase camera)
    {
        camera.Priority = 10;
        ActiveCamera = camera;

        foreach (CinemachineVirtualCameraBase cam in cameras)
        {
            if (cam != camera && cam.Priority !=0)
            {
                cam.Priority = 0;
            }
        }
    }

    public static void Register(CinemachineVirtualCameraBase camera)
    {
        cameras.Add(camera);
        Debug.Log("Camera registered: " + camera);
    }

    public static void Unregister(CinemachineVirtualCameraBase camera)
    {
        cameras.Remove(camera);
        Debug.Log("Camera unregistered: " + camera);
    }
}
