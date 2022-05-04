using UnityEngine;

public class GizmoBox : MonoBehaviour
{
    [SerializeField]
    private GameObject Checkpoint;
    public Color gizmoColor = Color.red;
    

    void OnDrawGizmos()
    {
        if(Checkpoint != null)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawCube(transform.position, new Vector3(Checkpoint.gameObject.transform.localScale.x, Checkpoint.gameObject.transform.localScale.y, Checkpoint.gameObject.transform.localScale.z));
        }
    }
}