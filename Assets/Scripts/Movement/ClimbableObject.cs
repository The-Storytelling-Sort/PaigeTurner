using UnityEngine;

public class ClimbableObject : MonoBehaviour
{
    // Imari - Triggers when the player enters the climbing area
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Climbing");
            ThirdPersonControllerNEW thirdPersonController = other.GetComponent<ThirdPersonControllerNEW>();
            LanternNEW lantern = other.GetComponent<LanternNEW>();
            InteractScript interact = other.GetComponent<InteractScript>();

            if (thirdPersonController != null && !lantern.isLantern)
                interact.detectClimb = true;
        }
    }

    // Imari - Returns the player controls to normal once the player exits the climbing area
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Exit Climb");
            ThirdPersonControllerNEW thirdPersonController = other.GetComponent<ThirdPersonControllerNEW>();
            InteractScript interact = other.GetComponent<InteractScript>();
            ClimbNEW climb = other.GetComponent<ClimbNEW>();

            if (thirdPersonController != null)
            {
                interact.detectClimb = false;
                climb.isClimbing = false;
            }
        }
    }
}
