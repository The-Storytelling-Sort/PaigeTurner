using UnityEngine;

public class UnflattenCheck : MonoBehaviour
{
    public bool canUnflatten = true;
    public float checkHeight;
    public LayerMask layer;
    
    private void Update()
    {
        RaycastHit hit;
        Ray unflattenRay = new Ray(transform.position, Vector3.up);
        
        if (Physics.Raycast(unflattenRay, out hit, checkHeight, layer))
        {
            Debug.DrawRay(transform.position, Vector3.up * checkHeight, Color.red);
            canUnflatten = false;
        }
        else
        {
            Debug.DrawRay(transform.position, Vector3.up * checkHeight, Color.green);
            canUnflatten = true;
        }
    }
}
