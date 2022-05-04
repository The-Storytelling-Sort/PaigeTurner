using UnityEngine;
using UnityEngine.SceneManagement;

public class UnlockAbility : MonoBehaviour
{
    public bool glideUnlocked;
    public bool frogJumpUnlocked;
    public bool lanternUnlocked;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "TurnersOffice")
        {
            glideUnlocked = false;
            frogJumpUnlocked = false;
            lanternUnlocked = false;
        }
        
        if (SceneManager.GetActiveScene().name == "Archives")
        {
            glideUnlocked = true;
            
            if (PlayerPrefs.GetInt("NorthWing") != 1)
                frogJumpUnlocked = false;
            else
            {
                frogJumpUnlocked = true;
            }
            
            lanternUnlocked = false;
        }
        
        if (SceneManager.GetActiveScene().name == "NorthWing")
        {
            glideUnlocked = true;
            frogJumpUnlocked = false;
            lanternUnlocked = false;
        }
        
        if (SceneManager.GetActiveScene().name == "EastWing")
        {
            glideUnlocked = true;
            frogJumpUnlocked = true;
            lanternUnlocked = false;
        }
        
        if (SceneManager.GetActiveScene().name == "WestWing")
        {
            glideUnlocked = true;
            frogJumpUnlocked = true;
            lanternUnlocked = false;
        }
        
        if (SceneManager.GetActiveScene().name == "Destroyed_archives")
        {
            glideUnlocked = true;
            frogJumpUnlocked = true;
            lanternUnlocked = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Glide Unlock"))
        {
            glideUnlocked = true;
        }
        
        if (other.CompareTag("Frog Jump Unlock"))
        {
            frogJumpUnlocked = true;
        }
        
        if (other.CompareTag("Lantern Unlock"))
        {
            lanternUnlocked = true;
        }
    }
}
