using UnityEngine;

public class SetParent : MonoBehaviour
{

    public GameObject Player;
    public GameObject playerBody;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.parent = transform;
            Debug.Log("On Platform");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.parent = null;
            Debug.Log("Off");
        }
    }
}
