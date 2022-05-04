using UnityEngine;

public class AiFiniteStateMachine : MonoBehaviour
{
    public Transform playerTransform;

    public Vector3 destinationPosition;
    [SerializeField]
    public GameObject[] pointList;

    public float shootRate;
    public float elapsedTime;

    public Transform turret { get; set; }
    public Transform bulletSpawnPoint { get; set; }

    public enum FSMState
    {
        None,
        Patrol,
        Chase,
        Attack,
        Dead,
    }

    protected virtual void Initialize() { }
    protected virtual void FSMUpdate() { }
    protected virtual void FSMFixedUpdate() { }
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        FSMUpdate();
    }

    private void FixedUpdate()
    {
        FSMFixedUpdate();
    }
}