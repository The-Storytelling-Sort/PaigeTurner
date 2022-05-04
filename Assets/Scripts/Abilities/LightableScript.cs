using UnityEngine;

public class LightableScript : MonoBehaviour
{
    Light lite;
    LanternNEW lantern;

    // Start is called before the first frame update
    void Start()
    {
        lite = GetComponentInChildren<Light>();
        lite.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lantern = other.gameObject.GetComponentInChildren<LanternNEW>();

            if (lantern.isLantern && lantern != null)
                TurnOnLight();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (lantern.isLantern && lantern != null)
                TurnOnLight();
        }
    }

    public void TurnOnLight()
    {
        lite.enabled = true;
    }
}
