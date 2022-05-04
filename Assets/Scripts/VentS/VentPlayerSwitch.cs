using UnityEngine;

//Attach this script to the player.
//Vents must be tagged by their direction for proper functionality
public class VentPlayerSwitch : MonoBehaviour
{
    public bool floorVent;
    public bool ceilingVent;
    public bool rightWallVent;
    public bool leftWallVent;



    public float windSpeed = 5f;

    ThirdPersonControllerNEW thirdPersonControllerNEW;
    GlideNEW glideNEW;
    LanternNEW lanternNEW;

    void Awake()
    {
        thirdPersonControllerNEW = GetComponent<ThirdPersonControllerNEW>();
        glideNEW = GetComponent<GlideNEW>();
        lanternNEW = GetComponent<LanternNEW>();
    }

    void Update()
    {
        if (floorVent)
        {
            thirdPersonControllerNEW.verticalVelocity = windSpeed;
        }

        if (ceilingVent)
        {
            thirdPersonControllerNEW.verticalVelocity = -windSpeed;
        }

        if (rightWallVent)
        {
            thirdPersonControllerNEW.horizontalVelocity = windSpeed;
        }

        if (leftWallVent)
        {
            thirdPersonControllerNEW.horizontalVelocity = -windSpeed;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "FloorVent")
        {
            floorVent = true;
        }

        if (collider.gameObject.tag == "CeilingVent")
        {
            ceilingVent = true;
        }

        if (collider.gameObject.tag == "RightWallVent")
        {
            rightWallVent = true;
        }

        if (collider.gameObject.tag == "LeftWallVent")
        {
            leftWallVent = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "FloorVent")
        {
            floorVent = false;
        }

        if (collider.gameObject.tag == "CeilingVent")
        {
            ceilingVent = false;
        }

        if (collider.gameObject.tag == "RightWallVent")
        {
            rightWallVent = false;
            thirdPersonControllerNEW.horizontalVelocity = 0f;
        }

        if (collider.gameObject.tag == "LeftWallVent")
        {
            leftWallVent = false;
            thirdPersonControllerNEW.horizontalVelocity = 0f;
        }

        if (glideNEW.isGliding || lanternNEW.isLantern)
        {
            thirdPersonControllerNEW.verticalVelocity = 0;
        }
    }
}

