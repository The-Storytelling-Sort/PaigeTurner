using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveProgress : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetString("Level", SceneManager.GetActiveScene().name);
    }

    public void SetProgress(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int GetProgress(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}
