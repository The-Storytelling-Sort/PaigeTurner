using UnityEngine;

public class GizmoPivot : MonoBehaviour
{
    public float gizmoSize = 5.0f;
    public Color gizmoColor = Color.red;

    void OnDrawGizmosSelected()
    {

        Gizmos.color = gizmoColor;
        Gizmos.DrawWireSphere(transform.position, gizmoSize);
    }
}
